namespace Avalonia.FuncUI.DSL

[<AutoOpen>]
module TemplatedControl =  
    open Avalonia.Media.Immutable
    open Avalonia
    open Avalonia.FuncUI.Types
    open Avalonia.FuncUI.Builder
    open Avalonia.Media
    open Avalonia.Controls.Primitives
    open Avalonia.Controls.Templates
    
    let create (attrs: IAttr<TemplatedControl> list): IView<TemplatedControl> =
        ViewBuilder.Create<TemplatedControl>(attrs)
        
    type TemplatedControl with
        static member background<'t when 't :> TemplatedControl>(value: IBrush) : IAttr<'t> =
            AttrBuilder.CreateProperty<'t, IBrush>(TemplatedControl.BackgroundProperty, value, ValueNone)
            
        static member background<'t when 't :> TemplatedControl>(color: string) : IAttr<'t> =
            Color.Parse(color) |> ImmutableSolidColorBrush |> TemplatedControl.background

        static member borderBrush<'t when 't :> TemplatedControl>(value: IBrush) : IAttr<'t> =
            AttrBuilder.CreateProperty<'t, IBrush>(TemplatedControl.BorderBrushProperty, value, ValueNone)
            
        static member borderBrush<'t when 't :> TemplatedControl>(color: string) : IAttr<'t> =
            Color.Parse(color) |> ImmutableSolidColorBrush |> TemplatedControl.borderBrush
            
        static member borderThickness<'t when 't :> TemplatedControl>(value: Thickness) : IAttr<'t> =
            AttrBuilder.CreateProperty<'t, Thickness>(TemplatedControl.BorderThicknessProperty, value, ValueNone)
            
        static member borderThickness<'t when 't :> TemplatedControl>(value: float) : IAttr<'t> =
            value |> Thickness |> TemplatedControl.borderThickness

        static member borderThickness<'t when 't :> TemplatedControl>(horizontal: float, vertical: float) : IAttr<'t> =
            (horizontal, vertical) |> Thickness |> TemplatedControl.borderThickness
            
        static member borderThickness<'t when 't :> TemplatedControl>(left: float, top: float, right: float, bottom: float) : IAttr<'t> =
            (left, top, right, bottom) |> Thickness |> TemplatedControl.borderThickness
            
        static member fontFamily<'t when 't :> TemplatedControl>(value: FontFamily) : IAttr<'t> =
            AttrBuilder.CreateProperty<'t, FontFamily>(TemplatedControl.FontFamilyProperty, value, ValueNone)
            
        static member fontSize<'t when 't :> TemplatedControl>(value: double) : IAttr<'t> =
            AttrBuilder.CreateProperty<'t, double>(TemplatedControl.FontSizeProperty, value, ValueNone)
            
        static member fontWeight<'t when 't :> TemplatedControl>(value: FontWeight) : IAttr<'t> =
            AttrBuilder.CreateProperty<'t, FontWeight>(TemplatedControl.FontWeightProperty, value, ValueNone)
            
        static member foreground<'t when 't :> TemplatedControl>(value: IBrush) : IAttr<'t> =
            AttrBuilder.CreateProperty<'t, IBrush>(TemplatedControl.ForegroundProperty, value, ValueNone)
            
        static member foreground<'t when 't :> TemplatedControl>(color: string) : IAttr<'t> =
            Color.Parse(color) |> ImmutableSolidColorBrush |> TemplatedControl.foreground
            
        static member padding<'t when 't :> TemplatedControl>(value: Thickness) : IAttr<'t> =
            AttrBuilder.CreateProperty<'t, Thickness>(TemplatedControl.PaddingProperty, value, ValueNone)
            
        static member padding<'t when 't :> TemplatedControl>(value: float) : IAttr<'t> =
            Thickness(value) |> TemplatedControl.padding
            
        static member padding<'t when 't :> TemplatedControl>(horizontal: float, vertical: float) : IAttr<'t> =
            Thickness(horizontal, vertical) |> TemplatedControl.padding
            
        static member padding<'t when 't :> TemplatedControl>(left: float, top: float, right: float, bottom: float) : IAttr<'t> =
            Thickness(left, top, right, bottom) |> TemplatedControl.padding 

        static member template<'t when 't :> TemplatedControl>(value: IControlTemplate) : IAttr<'t> =
            AttrBuilder.CreateProperty<'t, IControlTemplate>(TemplatedControl.TemplateProperty, value, ValueNone)  
        
        static member isTemplateFocusTarget<'t when 't :> TemplatedControl>(value: bool) : IAttr<'t> =
            AttrBuilder.CreateProperty<'t, bool>(TemplatedControl.IsTemplateFocusTargetProperty, value, ValueNone)  