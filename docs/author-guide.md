# Robin Build Position

## Contents

* [Introduction](#introduction)
* [Custom Building Data](#custom)
* [Editing Existing Building Data](#existing)

## Introduction<span id="introduction"></span>

This mod reads the `CustomFields` from a buildings data in the `Data/Buildings` asset.<br>
As such you will need to use Content Patcher to edit this field or if you're making a new building, set this field wherever you're setting up your building data.

## Custom Building Data<span id="custom"></span>

This example shows how to fill out `CustomFields` and at what indent level it goes:
```json
{
  "$schema": "https://smapi.io/schemas/content-patcher.json",
  "Format": "2.3.0",
  "Changes": [
    {
      "LogName": "Add example custom building",
      "Action": "EditData",
      "Target": "Data/Buildings",
      "Entries": {
        "{{ModId}}_ExampleBuilding": {
          "Name": "Example Building",
          "Description": "Example building.",
          "Texture": "{{ModId}}/ExBuilding",
          "Builder": "Robin",
          "CustomFields": {
            "rokugin.robinbuildposition": "64 64"
          }
        }
      }
    }
  ]
}
```

The actual position doesn't matter, as long as it's a field of the buildings data model.<br>

`CustomFields` takes `"<key>": "<value>"` pairs.<br>

You must have the key `"rokugin.robinbuildposition"`.<br>

The value is two space-delimited integers that differ depending on if the building has an interior or not.<br>
With interior: `"<TileCoordinateX> <TileCoordinateY>"`<br>
Without interior: `"<XPositionOffset> <YPositionOffset>"`<br>

Tile coordinates can be found in game using a mod or by opening the appropriate map in Tiled.<br>
Position offsets are in pixels, so 64 pixels is equivalent to a whole tile.<br>
Positive X offset moves Robin to the right, while positive Y offset moves Robin down.<br>

## Editing Existing Building Data<span id="existing"></span>

Editing an existing building's data requires the use of the `TargetField` field:
```json
{
  "$schema": "https://smapi.io/schemas/content-patcher.json",
  "Format": "2.3.0",
  "Changes": [
    {
      "Action": "EditData",
      "Target": "Data/Buildings",
      "TargetField": [
        "Silo",
        "CustomFields"
      ],
      "Entries": {
        "rokugin.robinbuildposition": "0 64"
      }
    },
    {
      "Action": "EditData",
      "Target": "Data/Buildings",
      "TargetField": [
        "Coop",
        "CustomFields"
      ],
      "Entries": {
        "rokugin.robinbuildposition": "1 6"
      }
    }
  ]
}
```

More info on how `TargetField` works can be found on the  <a href="https://github.com/Pathoschild/StardewMods/blob/develop/ContentPatcher/docs/author-guide/action-editdata.md#target-fields" target="_blank">CP docs</a>.<br>

`CustomFields` takes `"<key>": "<value>"` pairs, and since we've targeted `CustomFields` with our `TargetField` we can just directly provide our entry in `Entries`.<br>

You must have the key `"rokugin.robinbuildposition"`.<br>

The value is two space-delimited integers that differ depending on if the building has an interior or not.<br>
With interior: `"<TileCoordinateX> <TileCoordinateY>"`<br>
Without interior: `"<XPositionOffset> <YPositionOffset>"`<br>

Tile coordinates can be found in game using a mod or by opening the appropriate map in Tiled.<br>
Position offsets are in pixels, so 64 pixels is equivalent to a whole tile.<br>
Positive X offset moves Robin to the right, while positive Y offset moves Robin down.<br>
