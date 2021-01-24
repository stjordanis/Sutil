module TransitionParameters

open Sutil
open Sutil.Attr
open Sutil.DOM
open Sutil.Bindings
open Sutil.Transition

let view() =
    let visible = Store.make true

    Html.div [
        disposeOnUnmount [ visible ]

        Html.label [
            Html.input [
                type' "checkbox"
                bindAttr "checked" visible
            ]
            text " visible"
        ]
        transition [fly |> withProps [ Duration 2000.0; Y 200.0 ] |> InOut] visible <|
            Html.p [ text "Flies in and out" ]
    ]