module TextArea

// Adapted from
// https://svelte.dev/examples

open Sutil
open Feliz
open Sutil.Attr
open Sutil.DOM
open Sutil.Styling
open Fable.Core

[<ImportAll("./marked.min.js")>]
let marked text : string = jsNative

let sampleText =
     """## Markdown

- Some words are *italic*
- some are **bold**"""

let style = [
    rule "textarea" [
        Css.width  (length.percent 100)
        Css.height.custom (length.percent 100)
        Css.fontFamily "monospace"
        Css.padding 4
    ]

    rule "span" [
        Css.display.block
        Css.marginTop 40
    ]
]

let view() =
    let inputText = Store.make sampleText

    Html.div [
        disposeOnUnmount [inputText]

        Html.textarea [
            rows "5"
            Bind.attr("value",inputText)
        ]

        Html.span [
            Bind.fragment inputText <| fun t -> html $"{marked t}"
        ] |> withStyle Markdown.style
    ] |> withStyle style
