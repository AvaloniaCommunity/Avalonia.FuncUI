﻿namespace Inspector

[<AutoOpen>]
module AvaloniaExtensions =
    open Avalonia.Markup.Xaml.Styling
    open System
    open Avalonia.Styling

    type Styles with
        member this.Load (source: string) = 
            let style = new StyleInclude(baseUri = null)
            style.Source <- new Uri(source)
            this.Add(style)

[<RequireQualifiedAccess>]
module Analyzer =
    open System

    let findAllControls () : Type list = 
        let assemblies = AppDomain.CurrentDomain.GetAssemblies()
        [
            for assembly in assemblies do
                // maybe only use exported types
                for _type in assembly.GetTypes() do
                    // exclude interfaces
                    if not _type.IsInterface then
                        for _interface in  _type.GetInterfaces() do
                            if _interface = typeof<Avalonia.Controls.IControl> then
                                yield _type
        ]

    type AnalyzerProperty = {
        Name : string
        ValueType : Type
        HasGet : bool
        HasSet : bool
        Parent : Type list
    }

    let findAllProperties (): AnalyzerProperty list =
        let set = System.Collections.Concurrent.ConcurrentDictionary<(string * Type),AnalyzerProperty>()
        let controls = findAllControls()
        
        for control in controls do
            for propertyInfo in control.GetProperties() do
                let property = {
                    Name = propertyInfo.Name
                    ValueType = propertyInfo.PropertyType
                    HasGet = propertyInfo.CanRead
                    HasSet = propertyInfo.CanWrite
                    Parent = [ propertyInfo.DeclaringType ]
                }

                set.AddOrUpdate(
                    (property.Name, property.ValueType),
                    (fun key -> property),
                    (fun key old ->
                        if old.Parent |> List.contains propertyInfo.DeclaringType then
                            old
                        else
                            { old with Parent = old.Parent @ property.Parent}
                    )
                ) |> ignore
  
        (set.ToArray())
        |> List.ofArray
        |> List.map (fun i -> i.Value)

    type AnalyzerEvent = {
        Name : string
        ValueType : Type
        Parent : Type list
    }

    let findAllEvents (): AnalyzerEvent list =
        let set = System.Collections.Concurrent.ConcurrentDictionary<(string * Type), AnalyzerEvent>()
        let controls = findAllControls()
        
        for control in controls do
            for eventInfo in control.GetEvents() do
                let event = {
                    Name = eventInfo.Name
                    ValueType = eventInfo.EventHandlerType
                    Parent = [ eventInfo.DeclaringType ]
                }

                set.AddOrUpdate(
                    (event.Name, event.ValueType),
                    (fun key -> event),
                    (fun key old ->
                        if old.Parent |> List.contains eventInfo.DeclaringType then
                            old
                        else
                            { old with Parent = old.Parent @ event.Parent}
                    )
                ) |> ignore
  
        (set.ToArray())
        |> List.ofArray
        |> List.map (fun i -> i.Value)

