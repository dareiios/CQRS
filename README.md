
# CQRS Notes Application

## Task Description

The task is to develop a note-taking application.

The application should consist of two parts:

-   **Backend** - Core application logic.
-   **Database** - Information storage.

## Database

A database needs to be designed. The database should store information about notes, reminders, and tags.

All notes have the following information:

1.  Title
2.  Text
3.  Linked Tags

All reminders have the following information:

4.  Title
5.  Text
6.  Reminder Time
7.  Linked Tags

All tags have the following information:

8.  Name

## Backend

1.  The application logic must be implemented using **C# and .NET 7**.
2.  **Entity Framework Core** must be used as the ORM for data storage.
3.  **FluentValidation** must be used for data validation.
4.  An **API controller** must be created for each function.
5.  The **Repository pattern** must be implemented for database operations.
6.  **Services** must be developed for the core logic.
7.  Using the **CQRS paradigm**, implement a command to execute the core logic and an input data validator.
8.  The API controller receives a command as input and uses **MediatR** to execute it.
9.  **Unit tests** must be created.
10. The **database must be designed** according to the specifications.

## Required API Controllers

-   `POST /api/v1/function/note/create` - Create a note
-   `POST /api/v1/function/note/delete` - Delete a note
-   `POST /api/v1/function/note/update` - Edit a note
-   `POST /api/v1/function/note/get` - Get a note
-   `POST /api/v1/function/note/get-all` - Get all notes
-   `POST /api/v1/function/tag/create` - Create a tag
-   `POST /api/v1/function/tag/delete` - Delete a tag
-   `POST /api/v1/function/tag/update` - Edit a tag
-   `POST /api/v1/function/tag/get` - Get a tag
-   `POST /api/v1/function/tag/get-all` - Get all tags
-   `POST /api/v1/function/reminder/create` - Create a reminder
-   `POST /api/v1/function/reminder/delete` - Delete a reminder
-   `POST /api/v1/function/reminder/update` - Edit a reminder
-   `POST /api/v1/function/reminder/get` - Get a reminder
-   `POST /api/v1/function/reminder/get-all` - Get all reminders

## Functional Requirements

The user must be able to:

1.  Create a note.
2.  Edit a note.
3.  Set tags for a note (any number).
4.  Delete a note.
5.  View a note.
6.  View all their notes.
7.  Create a reminder.
8.  Edit a reminder.
9.  Set tags for a reminder (any number).
10. Delete a reminder.
11. View a reminder.
12. View all their reminders.
13. Create a tag.
14. Edit a tag.
15. Delete a tag.
16. View a tag.
17. View all their tags.
18. Link a tag.
