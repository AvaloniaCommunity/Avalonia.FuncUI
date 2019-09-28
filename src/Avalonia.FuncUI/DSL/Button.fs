namespace Avalonia.FuncUI.DSL

[<AutoOpen>]
module Button =
    open System
    open System.Threading
    open System.Windows.Input 
    
    open Avalonia.Controls
    open Avalonia.Interactivity
    open Avalonia.Input
    
    open Avalonia.FuncUI.Core.Domain
    
    let create (attrs: IAttr<Button> list): IView<Button> =
        View.create<Button>(attrs)
     
    type Button with

        static member clickMode<'t when 't :> Button>(value: ClickMode) : IAttr<'t> =
            let accessor = Accessor.Avalonia Button.ClickModeProperty
            let property = Property.createDirect(accessor, value)
            let attr = Attr.createProperty<'t> property
            attr :> IAttr<'t>
            
        static member command<'t when 't :> Button>(value: ICommand) : IAttr<'t> =
            let accessor = Accessor.Avalonia Button.CommandProperty
            let property = Property.createDirect(accessor, value)
            let attr = Attr.createProperty<'t> property
            attr :> IAttr<'t>
            
        static member hotKey<'t when 't :> Button>(value: KeyGesture) : IAttr<'t> =
            let accessor = Accessor.Avalonia Button.HotKeyProperty
            let property = Property.createDirect(accessor, value)
            let attr = Attr.createProperty<'t> property
            attr :> IAttr<'t>
            
        static member commandParameter<'t when 't :> Button>(value: #obj) : IAttr<'t> =
            let accessor = Accessor.Avalonia Button.CommandParameterProperty
            let property = Property.createDirect(accessor, value)
            let attr = Attr.createProperty<'t> property
            attr :> IAttr<'t>
            
        static member isDefault<'t when 't :> Button>(value: bool) : IAttr<'t> =
            let accessor = Accessor.Avalonia Button.IsDefaultProperty
            let property = Property.createDirect(accessor, value)
            let attr = Attr.createProperty<'t> property
            attr :> IAttr<'t>
            
        static member onClickRouted<'t when 't :> Button>(func: RoutedEventArgs -> unit) =
            let subscription = Subscription.createFromRoutedEvent (Button.ClickEvent, func)
            let attr = Attr.createSubscription<'t>(subscription)
            attr :> IAttr<'t>
            
        static member onClick<'t when 't :> Button>(func: RoutedEventArgs -> unit) =
            let factory (control: IControl, func: RoutedEventArgs -> unit, token: CancellationToken) =
                (control :?> Button).Click.Subscribe(func, token)
            
            let subscription = Subscription.createFromEvent ("Click", factory, func)
            let attr = Attr.createSubscription<'t>(subscription)
            attr :> IAttr<'t>

