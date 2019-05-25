﻿namespace rec Avalonia.FuncUI.Core

open Avalonia.Controls
open System
open Avalonia
open Avalonia.Interactivity

module Model =

    type PropertyAttr =
        {
            Property : AvaloniaProperty
            Value : obj
        }

    module PropertyAttr =
        let create (property: AvaloniaProperty, value: obj) =
            { Property = property; Value = value }

    [<RequireQualifiedAccess>]
    type ViewContent =
    | Single of ViewElement option
    | Multiple of ViewElement list

    type ContentAttr =
        {
            PropertyName : string
            Content : ViewContent
        }

    module ContentAttr =
        let create (property: string, content: ViewContent) =
            { PropertyName = property; Content = content }

    type EventAttr =
        {
            Event : RoutedEvent
            Args : Type
            Value : EventHandler
        }

    module EventAttr =
        let create (event: RoutedEvent<'t>, handler: EventHandler) =
            { Event = event; Args = typeof<'t>; Value = handler }

    type Attr =
        | Property of PropertyAttr
        | Content of ContentAttr
        | Event of EventAttr

        member this.Id =
            match this with
            | Property property ->
                "Property." + property.Property.Name
            | Content property ->
                "Content." + property.PropertyName
            | Event event ->
                "Event." + event.Event.Name

    module Attr =
        let createProperty (property: AvaloniaProperty, value: obj) =
            (property, value) |> PropertyAttr.create |> Property

        let createContent (property: string, content: ViewContent) =
            (property, content) |> ContentAttr.create |> Content

    type AttrInfo =
        {
            ViewType : Type
            Attr : Attr
        }

    module AttrInfo =
        let create(viewType: Type, attr : Attr) =
            { ViewType = viewType; Attr = attr }


    type ViewElement =
        {
            ViewType: Type
            Attrs: AttrInfo list
        }  

    module ViewElement =
        let create(viewType: Type, attrs: AttrInfo list) =
            { ViewType = viewType; Attrs = attrs; }
