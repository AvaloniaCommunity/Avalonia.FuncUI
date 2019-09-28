namespace Avalonia.FuncUI.DSL

[<AutoOpen>]
module Layoutable =  
    open Avalonia
    open Avalonia.FuncUI.Core.Domain
    open Avalonia.Layout
              
    type Layoutable with
        static member width<'t when 't :> Layoutable>(value: double) : IAttr<'t> =
            let accessor = Accessor.Avalonia Layoutable.WidthProperty
            let property = Property.createDirect(accessor, value)
            let attr = Attr.createProperty<'t> property
            attr :> IAttr<'t>
            
        static member height<'t when 't :> Layoutable>(value: double) : IAttr<'t> =
            let accessor = Accessor.Avalonia Layoutable.HeightProperty
            let property = Property.createDirect(accessor, value)
            let attr = Attr.createProperty<'t> property
            attr :> IAttr<'t>
            
        static member minWidth<'t when 't :> Layoutable>(value: double) : IAttr<'t> =
            let accessor = Accessor.Avalonia Layoutable.MinWidthProperty
            let property = Property.createDirect(accessor, value)
            let attr = Attr.createProperty<'t> property
            attr :> IAttr<'t>
            
        static member minHeight<'t when 't :> Layoutable>(value: double) : IAttr<'t> =
            let accessor = Accessor.Avalonia Layoutable.MinHeightProperty
            let property = Property.createDirect(accessor, value)
            let attr = Attr.createProperty<'t> property
            attr :> IAttr<'t>
      
        static member maxWidth<'t when 't :> Layoutable>(value: double) : IAttr<'t> =
            let accessor = Accessor.Avalonia Layoutable.MaxWidthProperty
            let property = Property.createDirect(accessor, value)
            let attr = Attr.createProperty<'t> property
            attr :> IAttr<'t>
            
        static member maxHeight<'t when 't :> Layoutable>(value: double) : IAttr<'t> =
            let accessor = Accessor.Avalonia Layoutable.MaxHeightProperty
            let property = Property.createDirect(accessor, value)
            let attr = Attr.createProperty<'t> property
            attr :> IAttr<'t>
            
        static member margin<'t when 't :> Layoutable>(margin: Thickness) : IAttr<'t> =
            let accessor = Accessor.Avalonia Layoutable.MarginProperty
            let property = Property.createDirect(accessor, margin)
            let attr = Attr.createProperty<'t> property
            attr :> IAttr<'t>
    
        static member horizontalAlignment<'t when 't :> Layoutable>(value: HorizontalAlignment) : IAttr<'t> =
            let accessor = Accessor.Avalonia Layoutable.HorizontalAlignmentProperty
            let property = Property.createDirect(accessor, value)
            let attr = Attr.createProperty<'t> property
            attr :> IAttr<'t>
   
        static member verticalAlignment<'t when 't :> Layoutable>(value: VerticalAlignment) : IAttr<'t> =
            let accessor = Accessor.Avalonia Layoutable.VerticalAlignmentProperty
            let property = Property.createDirect(accessor, value)
            let attr = Attr.createProperty<'t> property
            attr :> IAttr<'t>
           
        static member useLayoutRounding<'t when 't :> Layoutable>(value: bool) : IAttr<'t> =
            let accessor = Accessor.Avalonia Layoutable.UseLayoutRoundingProperty
            let property = Property.createDirect(accessor, value)
            let attr = Attr.createProperty<'t> property
            attr :> IAttr<'t>

