ShinyDate
=========

A nice shiny DateTime library of functions for C# .NET

ShinyDate
---------
A simple set of extention methods that help caclulate dates

```C#
//ShinyDate
DateTime tomorrow = DateTime.Today.Tomorrow();
DateTime yesterday = DateTime.Today.Yesterday();

DateTime nextMonday = DateTime.Today.GetNext(DayOfWeek.Monday);
DateTime lastTuesday = DateTime.Today.GetPrevious(DayOfWeek.Tuesday);

DateTime firstOfNextMonth = DateTime.Today.GetFirstOfNextMonth();
DateTime firstWednesdayOfNextMonth = DateTime.Today.GetFirstOfNextMonth(DayOfWeek.Wednesday);
DateTime secondTuesdayOfNextMonth = DateTime.Today.GetOccurrenceOfNextMonth(DayOfWeek.Tuesday, Occurrence.Second);

DateTime lastOfNextMonth = DateTime.Today.GetLastOfNextMonth();
DateTime lastFridayOfNextMonth = DateTime.Today.GetLastOfNextMonth(DayOfWeek.Friday);

DateTime nearestThursday = DateTime.Today.GetNearest(DayOfWeek.Thursday);
DateTime nearestLastFridayOfMonth = DateTime.Today.GetNearestOccurrence(DayOfWeek.Friday, Occurrence.Last);

DateTime fortnightFromToday = DateTime.Today.AddWeeks(2);

MonthOfYear todaysMonth = DateTime.Today.MonthOfYear();

bool IsLeapYear = DateTime.Today.IsInLeapYear();
bool IsTodayFirstMonday = DateTime.Today.IsOccurrenceOf(DayOfWeek.Monday, Occurrence.First);
```

ShinyDate.WorkingDays
---------------------
For caclulations around working days (working days assumed to be Mon-Fri)

```C#
//ShinyDateWorkingDays
DateTime nextWorkingDay = DateTime.Today.GetNextWorkingDay();
DateTime previousWorkingDay = DateTime.Today.GetPreviousWorkingDay();

DateTime firstWorkingDayOfNextMonth = DateTime.Today.GetFirstWorkingDayOfNextMonth();
DateTime lastWorkingDayOfNextmonth = DateTime.Today.GetLastWorkingDayOfNextMonth();

DateTime in20WorkingDays = DateTime.Today.AddWorkingDays(20);

bool isWorkingDay = DateTime.Today.IsWorkday();
bool isNotWorkingDay = DateTime.Today.IsNotWorkday();
```

ShinyDate.Collections
---------------------

```C#
//ShinyDateCollections
var daysFeb = ShinyDateCollections.GetAllDaysBetween(new DateTime(2014, 2, 1), new DateTime(2014, 2, 28))
var workingDaysFeb = ShinyDateCollections.GetAllWorkingDaysBetween(new DateTime(2014, 2, 1), new DateTime(2014, 2, 28))
var mondaysFeb = ShinyDateCollections.GetAllDayOfWeek(new DateTime(2014, 2, 1), new DateTime(2014, 2, 28), DayOfWeek.Monday)
var secondToLastFridaysOf2014 = ShinyDateCollections.GetAllOccurrences(new DateTime(2014, 1, 1), new DateTime(2014, 12, 31), DayOfWeek.Friday, Occurrence.SecondFromLast
```
