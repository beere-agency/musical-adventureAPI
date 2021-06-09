# Music Adventure API

A basic API to manage categories, tags and products for the application

## API Reference

#### Get all tags

```http
  GET /api/tags
```

| Parameter | Type     | Description                        |
| :-------- | :------- | :--------------------------------- |
| `bearer`  | `string` | **Required**. Authentication Token |

#### Get item

```http
  GET /api/items/${id}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `string` | **Required**. Id of item to fetch |

#### add(num1, num2)

Takes two numbers and returns the sum.

## Documentation

[Documentation](https://musicadventure.azurewebsites.net/swagger)

## ReadMe File

ReadMe file created with [ReadMe.So](https://readme.so)
