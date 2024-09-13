# Robin Build Position

## Contents

* [Introduction](#introduction)
* [Custom Building Data](#custom)
* [Editing Existing Building Data](#existing)

## Introduction<span id="introduction"></span>

This mod reads the `CustomFields` from a buildings data in the `Data/Buildings` asset.<br>
As such you will need to use Content Patcher to edit this field or if you're making a new building, set this field wherever you're setting up your building data.

## Custom Building Data<span id="custom"></span>

Below is an example of adding a new custom building (it's basically just a copy of the silo) with the `CustomFields` field filled out:
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
          "UpgradeSignTile": "1, 2",
          "UpgradeSignHeight": 16.0,
          "Size": {
            "X": 3,
            "Y": 3
          },
          "Builder": "Robin",
          "BuildDays": 2,
          "BuildCost": 100,
          "BuildMaterials": [
            {
              "ItemId": "(O)390",
              "Amount": 100
            },
            {
              "ItemId": "(O)330",
              "Amount": 10
            },
            {
              "ItemId": "(O)334",
              "Amount": 5
            }
          ],
          "CustomFields": {
            "rokugin.robinbuildposition": "64 64"
          }
        }
      }
    }
  ]
}
```

**Robin's position**<br>
When constructing a new building, Robin works from the Farm map and her position is a pixel offset from the center of the building.<br>

**Scale**<br>
Because the game scales up the original sprites by 4x, the world pixel size of one tile is 64x64.<br>

**Coordinates**<br>
Like tile coordinates, pixel coordinates `0, 0` start at the top left of the map.<br>
This means that a positive X value goes to the right and a positive Y value goes down.<br>

**CustomFields entry**<br>
As shown, the `CustomFields` field is a dictionary of `<string, string>` meaning it takes a plain text key entry and plain text value entry separated by `:`.<br>
Specifically for the outdoors position, the key is `rokugin.robinbuildposition` and the value is two space-delimited integers denoting the X and Y pixel offset.<br>
In the example, `64` pixels to the right and `64` pixels down.

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

**Robin's position**<br>
When upgrading a building with an interior, Robin's coordinates are normally locked specificaly to `1, 5` but can be set with this mod to any coordinates.<br>

**Coordinates**<br>
Robin's position is set in tile coordinates while indoors, so you can use a mod like Debug Mode or Lookup Anything to find the coordinates you want.<br>
You can also open the map in Tiled and get the coordinates there.<br>

**CustomFields entry**<br>
As before, the key of the entry is `rokugin.robinbuildposition` and the value is two space-delimited integers.<br>
Because it's tile coordinates, you'll generally not use negative values.<br>
In the example, the coop upgrade sets Robin's tile position to `1, 6`, which is one tile lower than her default position.
