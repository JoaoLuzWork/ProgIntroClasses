# 🏨 Hotel Silverstone — Console Booking System

A console-based hotel management application written in C# (.NET 10), built as part of an introductory programming course. It models a small hotel with rooms, guests, administrators and bookings, all held in memory for the lifetime of the run.

---

## 📖 About

Hotel Silverstone is an interactive command-line application that simulates a small hotel management system. It supports two user roles — guests and administrators — and covers registration, login, room browsing, bookings and profile management.

The project was developed as part of an introductory programming course to practise core object-oriented programming concepts in C#, including classes, static state, method dispatch, and console-based user interaction.

---

## 🛠️ Requirements

- .NET SDK 10.0 or later
- Any terminal (the app is fully interactive via the console)

---

## 🚀 Running

```bash
cd "C#/hotelProj"
dotnet run
```

The app boots straight into the main menu:

```
=========== Welcome to Hotel Silverstone! ===========

if you are a new user, please register first!
1. Registration
2. Login
3. Exit
```

---

## 🌱 Seed Data

The program starts with data hard-coded in `Program.Main`:

**Admin**

| Name           | Email             | Password |
| -------------- | ----------------- | -------- |
| Joao Rodrigues | joao@gmail.com    | 1234     |

**Rooms**

| Room Id | Number | Type   | Price / night | Available |
| ------- | ------ | ------ | ------------- | --------- |
| 0       | 101    | Single | 100.00        | yes       |
| 1       | 102    | Double | 150.00        | yes       |
| 2       | 103    | Suite  | 250.00        | no        |

There are no seeded guests — register one from the main menu first.

---

## 📂 Project Structure

```
C#/hotelProj/
├── hotelProj.csproj    Project file (net10.0, implicit usings, nullable enabled)
├── Program.cs          Entry point, in-memory data stores, main menu, login/registration
├── User.cs             Guest model + guest menu + profile editing
├── Admin.cs            Admin model + admin menu + listing screens
├── Room.cs             Room model + room CRUD + availability listing
└── Bookings.cs         Booking model + booking CRUD for both guests and admins
```

`bin/` and `obj/` are build output and can be regenerated with `dotnet build`.

---

## 🔧 How It Fits Together

`Program` acts as the in-memory database. Four static lists hold every entity, and two static fields track who is signed in:

```csharp
public static List<User> users;
public static List<Admin> admins;
public static List<Room> rooms;
public static List<Bookings> bookings;
public static Admin currentAdmin;
public static User currentUser;
```

Every other class reaches into those lists directly (`Program.rooms.Find(...)`), and each screen is a static method that prints a header, reads input with `Console.ReadLine()`, mutates the lists, then calls the menu method it came from. Navigation is therefore **call-based rather than loop-based** — `Room.AvailableRooms()` ends by calling `User.DisplayUserMenu()`, which dispatches the next choice through a `switch`.

Login checks the admin list first, then the guest list, so **admins always win on a matching email/password pair**. Three consecutive failures bounce back to the main menu.

---

## ✨ Features

### 👤 Guest Menu

| # | Option                | Backing Method              |
| - | --------------------- | --------------------------- |
| 1 | View available rooms  | `Room.AvailableRooms()`     |
| 2 | Book a room           | `Bookings.BookRoom()`       |
| 3 | View my bookings      | `Bookings.ViewMyBookings()` |
| 4 | Cancel booking        | `Bookings.CancelBooking()`  |
| 5 | Update booking dates  | `Bookings.UpdateBooking()`  |
| 6 | Edit profile          | `User.EditProfile()`        |
| 7 | Logout                | back to main menu           |

Guests only ever see their own bookings — every lookup is filtered by `b.CustomerId == Program.currentUser.UserId`.

### 🛡️ Admin Menu

Register another admin, list admins / guests / rooms / bookings, full room CRUD (add, edit, delete, toggle availability) and full booking CRUD on behalf of any guest.

### 📅 Booking Rules

- Check-out must be strictly **after** check-in
- Total is `(checkOut - checkIn).Days * room.PricePerNight`
- Booking a room sets `IsAvailable = false`; cancelling or deleting sets it back to `true`

---

## ⚠️ Known Limitations

These are worth knowing before extending the project — several are natural next exercises.

- **No persistence.** Everything lives in `List<T>`; closing the app discards all guests and bookings. Only the seeded admin and rooms come back.
- **Passwords in plain text.** Stored as-is on the model and compared directly. Fine for a class exercise, not for anything real.
- **No input validation.** `Convert.ToInt32` / `Convert.ToDecimal` / `Convert.ToDateTime` throw on anything unexpected, so typing a letter at a menu prompt crashes the app.
- **Retries recurse instead of loop.** A failed lookup calls its own method again, and execution continues after that call returns. In `AddBooking` and `BookRoom` a missing room means the code falls through to `room.PricePerNight` on a null reference. The same pattern makes every menu a growing call stack rather than a loop.
- **`EditBooking` dereferences before checking.** It looks up the room using `bookingToEdit.RoomId` before the `bookingToEdit != null` check, so an unknown booking id throws.
- **Admin actions assume `admins[0]`.** Room and booking screens return via `Program.admins[0].DisplayAdminMenu()` rather than `currentAdmin`, so a second admin ends up in the first admin's menu.
- **Duplicate emails are allowed.** Registration does not check whether an email is already taken (flagged in a `// to be implemented` comment in `Program.cs`).
- **No date-overlap check.** Availability is a single boolean, so a room cannot be booked for two separate future date ranges.
- **Build output is committed.** Adding a `.gitignore` with `bin/` and `obj/` would keep the repo clean.

---

## 🔮 Possible Next Steps

- [ ] Wrap menus in `while` loops and drop the recursive re-entry
- [ ] Add a `TryParse`-based input helper for ints, decimals and dates
- [ ] Persist the four lists to JSON on exit and reload them on start
- [ ] Hash passwords, and reject duplicate emails at registration
- [ ] Replace the `IsAvailable` flag with a per-date overlap check against existing bookings

---

## 👤 Author

**João Pedro Luz**

- GitHub: [@JoaoLuzWork](https://github.com/JoaoLuzWork)
- Email: <joao.pedro.luz.work@gmail.com>
- Location: Dublin, Ireland

---

## 📄 License

This project is open source and available for personal and educational use.
