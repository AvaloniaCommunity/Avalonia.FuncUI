﻿namespace CounterElmishSample

open Avalonia.Controls
open Avalonia.Media
open Avalonia.FuncUI.Types
open Avalonia.FuncUI

module Counter =

    type CounterState = {
        count : int
    }

    let init = {
        count = 0
    }

    type Msg =
    | Increment
    | Decrement

    let update (msg: Msg) (state: CounterState) : CounterState =
        match msg with
        | Increment -> { state with count =  state.count + 1 }
        | Decrement -> { state with count =  state.count - 1 }
    
    let view (state: CounterState) (dispatch): View =
        Views.stackpanel [
            Attrs.orientation Orientation.Horizontal
            Attrs.children [
                Views.textblock [
                    Attrs.text (sprintf "the count is %i" state.count)
                ]
                Views.button [
                    Attrs.click (fun sender args -> dispatch Increment)
                    Attrs.content (
                        Views.textblock [
                            Attrs.text "click to increment"
                        ]
                    )
                ]
                Views.button [
                    Attrs.click (fun sender args -> dispatch Decrement)
                    Attrs.content (
                        Views.textblock [
                            Attrs.text "click to decrement"
                        ]
                    )
                ]
            ]
        ]       
