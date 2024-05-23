# Project .NET Framework

* Naam: Arthur Linsen
* Studentennummer: 054206-73
* Academiejaar: 22-23
* Klasgroep: INF201B
* Onderwerp: Fitness - Member - Exercise

## Sprint 3

### Beide zoekcriteria ingevuld

```
SELECT "m"."Id", "m"."Birthdate", "m"."BodyWeight", "m"."FitnessId", "m"."Name"
FROM "Member" AS "m"
WHERE ((@__ToLower_0 = '') OR (instr(lower("m"."Name"), @__ToLower_0) > 0)) AND ("m"."Birthdate" = @__date_1)
```

### Enkel zoeken op naam

```
SELECT "m"."Id", "m"."Birthdate", "m"."BodyWeight", "m"."FitnessId", "m"."Name"
FROM "Member" AS "m"
WHERE ((@__ToLower_0 = '') OR (instr(lower("m"."Name"), @__ToLower_0) > 0)) AND ("m"."Birthdate" = @__date_1)
```

### Enkel zoeken op geboortedatum

```
SELECT "m"."Id", "m"."Birthdate", "m"."BodyWeight", "m"."FitnessId", "m"."Name"
FROM "Member" AS "m"
WHERE ((@__ToLower_0 = '') OR (instr(lower("m"."Name"), @__ToLower_0) > 0)) AND ("m"."Birthdate" = @__date_1)
```

### Beide zoekcriteria leeg

```
SELECT "m"."Id", "m"."Birthdate", "m"."BodyWeight", "m"."FitnessId", "m"."Name"
FROM "Member" AS "m"
WHERE ((@__ToLower_0 = '') OR (instr(lower("m"."Name"), @__ToLower_0) > 0)) AND ("m"."Birthdate" = @__date_1)
```

## Sprint 6

### Nieuwe fitness

#### Request

```
POST https://localhost:5001/api/fitnesses
Content-Type: application/x-www-form-urlencoded

name=Fitness Arthur&address=Hulseinde 8&surface=50
```

#### Response

```
HTTP/1.1 201 Created
Content-Type: application/json; charset=utf-8
Date: Mon, 07 Aug 2023 14:38:32 GMT
Server: Kestrel
Location: https://localhost:5001/Fitness
Transfer-Encoding: chunked

{
  "name": "Fitness Arthur",
  "address": "Hulseinde 8",
  "surface": 50
}
```