namespace Avalonia.FuncUI.DSL

[<AutoOpen>]
module Animatable =  
    open Avalonia.Animation
    open Avalonia.FuncUI.Types
    
    type Animatable with
        static member transitions<'t when 't :> Animatable>(transitions: Transitions) : IAttr<'t> =
            let accessor = Accessor.AvaloniaProperty Animatable.TransitionsProperty
            let property = Property.createDirect(accessor, transitions)
            let attr = Attr.createProperty<'t> property
            attr :> IAttr<'t>
            
        static member clock<'t when 't :> Animatable>(clock: IClock) : IAttr<'t> =
            let accessor = Accessor.AvaloniaProperty Animatable.ClockProperty
            let property = Property.createDirect(accessor, clock)
            let attr = Attr.createProperty<'t> property
            attr :> IAttr<'t>