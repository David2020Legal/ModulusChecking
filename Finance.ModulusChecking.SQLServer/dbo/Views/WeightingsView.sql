CREATE View WeightingsView AS
SELECT ID As WeightingId, 1 As Digit, WeightingDigit1 As Value
FROM Weightings
UNION
SELECT ID, 2, WeightingDigit2
FROM Weightings
UNION
SELECT ID, 3, WeightingDigit3
FROM Weightings
UNION
SELECT ID, 4, WeightingDigit4
FROM Weightings
UNION
SELECT ID, 5, WeightingDigit5
FROM Weightings
UNION
SELECT ID, 6, WeightingDigit6
FROM Weightings
UNION
SELECT ID, 7, WeightingDigit7
FROM Weightings
UNION
SELECT ID, 8, WeightingDigit8
FROM Weightings
UNION
SELECT ID, 9, WeightingDigit9
FROM Weightings
UNION
SELECT ID, 10, WeightingDigit10
FROM Weightings
UNION
SELECT ID, 11, WeightingDigit11
FROM Weightings
UNION
SELECT ID, 12, WeightingDigit12
FROM Weightings
UNION
SELECT ID, 13, WeightingDigit13
FROM Weightings
UNION
SELECT ID, 14, WeightingDigit14
FROM Weightings
