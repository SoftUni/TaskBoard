# TaskBoard
Trello-style task board, holding tasks in boards (Open, In Progress, Done)

* Technologies: .NET 6, ASP.NET MVC Core, Entity Framework Core, MS SQL Server
* The app supports the following operations:
   - Home page (view tasks count + menu): `/`
   - View the boards with tasks: `/Boards`
   - Search tasks by keyword: `/Tasks/Search`
   - View task details (by id): `/Tasks/Details/:id`
   - Add new task (title + description + board): `/Tasks/Create`
   - Edit task / move to board: `/Tasks/Edit/:id`
   - Delete task: `/Tasks/Delete/:id`

## TaskBoard RESTful API
The following endpoints are supported:
 - `GET /api` - list all API endpoints
 - `GET /api/boards` - list all boards
 - `GET /api/tasks` - list all tasks
 - `GET /api/tasks/count` - returns tasks count
 - `GET /api/tasks/:id` - returns a task by given `id`
 - `GET /api/tasks/search/:keyword` - list all tasks matching given keyword
 - `GET /api/tasks/board/:boardName` - list tasks by board
 - `POST /api/tasks/create` - create a new task (post a JSON object in the request body, e.g. `{"title": "Add Tests", "description": "API + UI tests", "board": "Open"}`)
 - `PUT /api/tasks/:id` - edit task by `id` (send a JSON object in the request body, holding all fields, e.g. `{"title": "changed title", "description": "changed description", "board": "Done"}`)
 - `PATCH /api/tasks/:id` - partially edit task by `id` (send a JSON object in the request body, holding the fields to modify, e.g. `{"title":"changed title", "board":"Done"}`)
 - `DELETE /api/tasks/:id` - delete task by `id`
 - `GET /api/users` - list all users
 - `POST /api/users/login` - logs in an existing user (send a JSON object in the request body, holding all fields, e.g. `{"username": "username", "password": "pass123"}`)
 - `POST /api/users/register` - registers a new user (send a JSON object in the request body, holding all fields, e.g. `{"username": "username", "email": "user@example.com", "password": "pass123", "confirmPassword": "pass123", "firstName": "Test", "lastName": "User"}`)

## Screenshots

### TaskBoard Web App
<kbd>![image](https://user-images.githubusercontent.com/69080997/136532033-95b5d2e7-aa94-4a6e-b287-7ac19e5038c7.png)</kbd>
<kbd>![image](https://user-images.githubusercontent.com/69080997/136532515-056ee460-5c2c-466c-acab-db2a2f2e72d7.png)</kbd>
<kbd>![image](https://user-images.githubusercontent.com/69080997/136532672-6814afc2-0d0c-4059-b428-7dafaad3dcb5.png)</kbd>
<kbd>![image](https://user-images.githubusercontent.com/69080997/136533230-bb9dbdb8-8254-4663-b5c4-f24fe5b4d75b.png)</kbd>
<kbd>![image](https://user-images.githubusercontent.com/69080997/136532870-924f253f-3aef-4e4a-b8f8-b339cb146999.png)</kbd>
<kbd>![image](https://user-images.githubusercontent.com/69080997/136533398-0811e782-5395-4b39-9517-ea61397531ac.png)</kbd>

### TaskBoard RESTful API

<kbd>![image](https://user-images.githubusercontent.com/69080997/133220280-5935b769-fc0a-4d95-a292-828e382abdd1.png)</kbd>
<kbd>![image](https://user-images.githubusercontent.com/69080997/133220374-c9a58879-9b54-4042-b728-d6d9c2b6a1e5.png)</kbd>
<kbd>![image](https://user-images.githubusercontent.com/69080997/133220463-d4c9d910-73d0-49c9-86a2-df99ff6eadc1.png)</kbd>
