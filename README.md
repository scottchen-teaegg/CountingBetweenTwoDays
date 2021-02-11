# CountingBetweenTwoDays

Calculates the number of weekdays in between two dates.
● Weekdays are Monday, Tuesday, Wednesday, Thursday, Friday.
● The returned count should not include either firstDate or secondDate -
e.g. between Monday 07-Oct-2013 and Wednesday 09-Oct-2013 is one weekday.
● If secondDate is equal to or before firstDate, return 0.

Calculate the number of business days in between two dates.
● Business days are Monday, Tuesday, Wednesday, Thursday, Friday, but excluding any
dates which appear in the supplied list of public holidays.
● The returned count should not include either firstDate or secondDate - e.g. between Monday
07-Oct-2013 and Wednesday 09-Oct-2013 is one weekday.
● If secondDate is equal to or before firstDate, return 0


Calculate the number of business days in between two dates (with HolidayRules).
Current supported rules:
● Public holidays which are always on the same day, e.g. Anzac Day on April 25th every year.
● Public holidays which are always on the same day, except when that falls on a weekend. e.g. New
Year's Day on January 1st every year, unless that is a Saturday or Sunday, in which case the
holiday is the next Monday.
● Public holidays on a certain occurrence of a certain day in a month. e.g. Queen's Birthday on the
second Monday in June every year.
● The rule is extendable and to enable more business logics by implementing the interface IHolidayChecker 
