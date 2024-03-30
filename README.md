# QueryApp

This project is a simple web application that allows clients to enter queries,
which are then stored in a database and displayed effectively.
It is built using .NET Core and Razor Pages.

![Docket](https://user-images.githubusercontent.com/27886422/174475965-24ba51c9-3f0b-4630-89aa-5a5bd62a2d2f.png)

## Table of Contents

* [Dependencies](#dependencies)
* [Installation](#installation)
* [Configuration](#configuration)
* [Mouse Actions](#mouse-actions)
  * [Important Note](#important-note)

## Dependencies

Of course, you're gonna need [Rainmeter](https://www.rainmeter.net/), but that's about it.

## Installation

Go to the [releases tab](https://github.com/ChuseCubr/RM-Docket/releases), download the .rmskin file, and open it with Rainmeter.

Edit `Schedule\schedule.csv` to your needs. By default, it's set to ISO weeks (Sunday first day of the week). To change this, please see the [configuration section](#configuration).

> If you want to turn off or change the example mouse actions, go into the `Schedule\Actions` folder and edit the CSV files.

## Configuration

On top of configurable styles, you can also adjust the layout in `Schedule\schedule.ini`

```ini
;-- schedule.ini
[Variables]
; vertical layout
VerticalMode=0

; spacing between each subject
Spacing=200

; toggle displaying the time label above the subject
TimeAbove=0

; adjust spacing between subject and time range
TimeOffset=30

; toggle the built-in hover action (change color)
ChangeStyleOnHover=1

; subject name align
LabelAlign=Center

; subject status colors (needed for hover action)
OngoingColor="255,255,255,200"
UpComingColor="255,255,255,200"
CompletedColor="255,255,255,100"

OngoingHoverColor="255,255,255,255"
UpComingHoverColor="255,255,255,255"
CompletedHoverColor="255,255,255,180"

; see important notes
Delimiter=,
```

By default, the schedule is by iso week (starts on Sunday), but you can change this in line 380 of `Schedule\schedule.lua`:

```lua
-- schedule.lua
function Update()
    -- +2 = iso week (Sunday first day of the week)
    -- +1 = non iso week (Monday first day of the week)
    local day = os.date("%w") + 2
```

Times must be in a `HH:MM` 24-hour format in order to work properly (see preview or download skin for an example).

## Mouse Actions

Here are some custom mouse actions in action:

![suite_showcase](https://user-images.githubusercontent.com/27886422/159912205-dd269250-f1c4-47ee-b858-f598084b8074.gif)

The skin already has built-in MouseOverActions for changing colors, but you can extend these with your own.

Creating a CSV file in the `Schedule\Actions` folder named after the mouse action will add that functionality to the schedule ([example](https://github.com/ChuseCubr/RM-Docket/tree/main/Schedule/Actions)).

Similarly to how you set a mouse action for meters, these actions are set through bangs. Each cell will map to its counterpart in `Schedule\schedule.csv`. The skin and the showcase above have these custom actions:

* [LeftMouseDownAction](https://github.com/ChuseCubr/RM-Docket/blob/main/Schedule/Actions/LeftMouseDownAction.csv): open a link in your browser
* [MouseOverAction](https://github.com/ChuseCubr/RM-Docket/blob/main/Schedule/Actions/MouseOverAction.csv): display some text (set in `Description\`)
* [MouseLeaveAction](https://github.com/ChuseCubr/RM-Docket/blob/main/Schedule/Actions/MouseLeaveAction.csv): stop displaying text (set in `Description\`)

### Important Note

I'm too small-brained to properly parse CSV files, so substitutions to certain characters must be made in order to:

* allow Excel to save to a parsable format (no quotes), and
* be able to parse columns properly (no excess separators)

I'm only aware of two substitutions that need to be done:

| From | To |
|:--|:--|
| Quotes (`"`) | Escaped apostrophes (`\'`) |
| Separators. This depends on region; a common one is commas (`,`) | `\sep ` (note the space. If you want a space after, you must add another.) |

For example:

```
[!SetOption Title Text \'Hello\sep  world! I'm alive!\']
    notice the 2 spaces ----------^^
```

Features
Query Submission:
Clients can submit queries via the web interface.
The submitted queries are stored in the database.
Query Display:
The website displays a list of all submitted queries.
Each query is shown with relevant details (e.g., timestamp, user, query text).
Database Integration:
The application uses a database (e.g., SQL Server, SQLite) to store query data.
Connection string configuration is provided in appsettings.json.
Getting Started
Prerequisites:
Install .NET Core SDK (version X.X or higher).
Set up your preferred database (e.g., SQL Server, SQLite).
Clone the Repository:
git clone https://github.com/yourusername/simple-query-website.git

Configure Database:
Update the connection string in appsettings.json to point to your database.
Run database migrations:
dotnet ef database update

Run the Application:
dotnet run

Access the Website:
Open your web browser and navigate to http://localhost:5000.
Contributing
Contributions are welcome! If you find any issues or have suggestions, feel free to create a pull request.

License
This project is licensed under the MIT License - see the LICENSE file for details.
