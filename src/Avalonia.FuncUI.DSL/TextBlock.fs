namespace Avalonia.FuncUI.DSL

[<AutoOpen>]
module TextBlock =  
    open Avalonia.Controls
    open Avalonia.Media.Immutable
    open Avalonia.Media    

    open Avalonia.FuncUI.Types

    let create (attrs: IAttr<TextBlock> list): IView<TextBlock> =
        View.create<TextBlock>(attrs)
    
    type TextBlock with
            
        static member text<'t when 't :> TextBlock>(value: string) : IAttr<'t> =
            let accessor = Accessor.AvaloniaProperty TextBlock.TextProperty
            let property = Property.createDirect(accessor, value)
            let attr = Attr.createProperty<'t> property
            attr :> IAttr<'t>    
            
        static member background<'t when 't :> TextBlock>(value: IBrush) : IAttr<'t> =
            let accessor = Accessor.AvaloniaProperty TextBlock.BackgroundProperty
            let property = Property.createDirect(accessor, value)
            let attr = Attr.createProperty<'t> property
            attr :> IAttr<'t>
            
        static member background<'t when 't :> TextBlock>(color: string) : IAttr<'t> =
            let accessor = Accessor.AvaloniaProperty TextBlock.BackgroundProperty
            let property = Property.createDirect(accessor, ImmutableSolidColorBrush(Color.Parse(color)))
            let attr = Attr.createProperty<'t> property
            attr :> IAttr<'t>    
        
        static member fontFamily<'t when 't :> TextBlock>(value: FontFamily) : IAttr<'t> =
            let accessor = Accessor.AvaloniaProperty TextBlock.FontFamilyProperty
            let property = Property.createDirect(accessor, value)
            let attr = Attr.createProperty<'t> property
            attr :> IAttr<'t>
            
        static member fontSize<'t when 't :> TextBlock>(value: double) : IAttr<'t> =
            let accessor = Accessor.AvaloniaProperty TextBlock.FontSizeProperty
            let property = Property.createDirect(accessor, value)
            let attr = Attr.createProperty<'t> property
            attr :> IAttr<'t>
            
        static member fontStyle<'t when 't :> TextBlock>(value: FontStyle) : IAttr<'t> =
            let accessor = Accessor.AvaloniaProperty TextBlock.FontStyleProperty
            let property = Property.createDirect(accessor, value)
            let attr = Attr.createProperty<'t> property
            attr :> IAttr<'t>
            
        static member fontWeight<'t when 't :> TextBlock>(value: FontWeight) : IAttr<'t> =
            let accessor = Accessor.AvaloniaProperty TextBlock.FontWeightProperty
            let property = Property.createDirect(accessor, value)
            let attr = Attr.createProperty<'t> property
            attr :> IAttr<'t>
            
        static member foreground<'t when 't :> TextBlock>(value: IBrush) : IAttr<'t> =
            let accessor = Accessor.AvaloniaProperty TextBlock.ForegroundProperty
            let property = Property.createDirect(accessor, value)
            let attr = Attr.createProperty<'t> property
            attr :> IAttr<'t>
            
        static member foreground<'t when 't :> TextBlock>(color: string) : IAttr<'t> =
            Color.Parse(color) |> ImmutableSolidColorBrush |> TextBlock.foreground
            
        static member textAlignment<'t when 't :> TextBlock>(alignment: TextAlignment) : IAttr<'t> =
            let accessor = Accessor.AvaloniaProperty TextBlock.TextAlignmentProperty
            let property = Property.createDirect(accessor, alignment)
            let attr = Attr.createProperty<'t> property
            attr :> IAttr<'t>
            
        static member textWrapping<'t when 't :> TextBlock>(value: TextWrapping) : IAttr<'t> =
            let accessor = Accessor.AvaloniaProperty TextBlock.TextWrappingProperty
            let property = Property.createDirect(accessor, value)
            let attr = Attr.createProperty<'t> property
            attr :> IAttr<'t>

