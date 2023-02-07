# netcore5-backend-api
A NetCore5 API for creating and Fetching records from code first database

This API has 2 endpoints

1) CreatePerson
2) GetRecords 

**CreatePerson** is a vaersatile endpoint that let's the API User POST data to the API with content-type header set to any one of these multipart/form-data, application/json
and Query params.

**<h1>Sample POST Body when content-type is application/json</h1>** 

```bash

curl --location --request POST 'https://localhost:44393/api/person/CreatePerson' \
--header 'Content-Type: application/json' \
--data-raw '{
    "FullName": "Nitin Shukla",
    "Age": "31"    
}'

```

**<h1>POST Response</h1>**

```JSON

{
    "id": 13,
    "fullName": "Nitin Shukla",
    "age": 31,
    "createdOnUtc": "2023-02-07T10:40:11.721123Z",
    "modifiedOnUtc": "2023-02-07T10:40:11.7212683Z"
}

```

**<h1>Sample POST Body when content-type is multipart/form-data</h1>** 

```bash

curl --location --request POST 'https://localhost:44393/api/person/CreatePerson' \
--form 'FullName="Steve Tendy"' \
--form 'Age="51"'

```

**<h1>POST Response</h1>**

```JSON

{
    "id": 14,
    "fullName": "Steve Tendy",
    "age": 51,
    "createdOnUtc": "2023-02-07T10:42:41.1942812Z",
    "modifiedOnUtc": "2023-02-07T10:42:41.1942829Z"
}

```

**<h1>Sample POST Body when content-type is multipart/form-data</h1>** 

```bash

curl --location --request POST 'https://localhost:44393/api/person/CreatePerson?FullName=Daniel&Age=25'

```

**<h1>POST Response</h1>**

```JSON

{
    "id": 15,
    "fullName": "Daniel",
    "age": 25,
    "createdOnUtc": "2023-02-07T10:44:38.4297396Z",
    "modifiedOnUtc": "2023-02-07T10:44:38.4297413Z"
}

```

**GetRecords** is a GET endpoint that takes in 2 parameters param1 = stringToMatch and param2 = searchCriteria.

This would match all Person Records from the Database and return matching Person records whose full Name property either contains/equals (depending upon searchCriteria = 1 or 2)

**<h1> Sample Request curl for GETRecords endpoint</h1>**

```bash

curl --location --request GET 'https://localhost:44393/api/person/GetRecords'

```

**<h1>Sample Response from GETRecords endpoint</h1>**

```JSON

[
    {
        "id": 5,
        "fullName": "Nitin Shukla",
        "age": 31,
        "createdOnUtc": "2023-02-07T08:22:54.4171321",
        "modifiedOnUtc": "2023-02-07T08:22:54.4172011"
    },
    {
        "id": 6,
        "fullName": "Steve Tendy",
        "age": 51,
        "createdOnUtc": "2023-02-07T08:23:36.4913094",
        "modifiedOnUtc": "2023-02-07T08:23:36.4913164"
    },
    {
        "id": 8,
        "fullName": "Nitin Shukla",
        "age": 31,
        "createdOnUtc": "2023-02-07T09:03:09.7563924",
        "modifiedOnUtc": "2023-02-07T09:03:09.7566563"
    },
    {
        "id": 9,
        "fullName": "Nitin Shukla",
        "age": 31,
        "createdOnUtc": "2023-02-07T09:03:20.0081197",
        "modifiedOnUtc": "2023-02-07T09:03:20.0081242"
    },
    {
        "id": 10,
        "fullName": "Nitin Shukla",
        "age": 31,
        "createdOnUtc": "2023-02-07T09:03:22.1687118",
        "modifiedOnUtc": "2023-02-07T09:03:22.1687137"
    },
    {
        "id": 11,
        "fullName": "Nitin Shukla",
        "age": 31,
        "createdOnUtc": "2023-02-07T09:03:24.2564959",
        "modifiedOnUtc": "2023-02-07T09:03:24.2564982"
    },
    {
        "id": 12,
        "fullName": "Daniel Cox",
        "age": 31,
        "createdOnUtc": "2023-02-07T09:32:32.5216429",
        "modifiedOnUtc": "2023-02-07T09:32:32.5217562"
    },
    {
        "id": 13,
        "fullName": "Nitin Shukla",
        "age": 31,
        "createdOnUtc": "2023-02-07T10:40:11.721123",
        "modifiedOnUtc": "2023-02-07T10:40:11.7212683"
    },
    {
        "id": 14,
        "fullName": "Steve Tendy",
        "age": 51,
        "createdOnUtc": "2023-02-07T10:42:41.1942812",
        "modifiedOnUtc": "2023-02-07T10:42:41.1942829"
    },
    {
        "id": 15,
        "fullName": "Daniel",
        "age": 25,
        "createdOnUtc": "2023-02-07T10:44:38.4297396",
        "modifiedOnUtc": "2023-02-07T10:44:38.4297413"
    }
]

```

This endpoint will serve as the backend for a Single page React-App we will use to display data fetched via GetRecords call on a Grid.
