# 📚 ProgIntroClasses — Introduction to Programming Coursework

Coursework from my introduction to programming classes. Two small, self-contained console applications — one in Python, one in C# — built while learning the fundamentals of each language.

---

## 📖 About

This repository gathers the exercises and small projects I built while getting to grips with the core building blocks of programming. Both projects are console applications, written from scratch in their respective languages, and both use the same underlying idea: model the domain with classes, keep the data in a list that stands in for a database, and drive everything through a menu.

Neither project pulls in a framework or an external package — the point was to learn the languages, not the libraries. Neither project saves anything either: close the program and the data is gone. That is deliberate for the exercise — the lists stand in for a database while the focus stays on the language itself.

---

## ✨ Features

- 🐍 **Python — Product Management System** — Single-file inventory manager (`managementProgram.py`) with a `Product` class and a `ProductsManagementSystem` class holding the collection
- 🏨 **C# — Hotel Silverstone** — Console hotel booking system split across five files (`Program`, `User`, `Admin`, `Room`, `Bookings`) with static lists as the in-memory database
- ➕ **Full CRUD** — Add, list, search, edit and delete across both projects
- 👥 **Role-Based Access (C#)** — Separate guest and admin menus, with admins getting broader permissions
- 🔍 **Search & Filter** — Look up products by id or name; guests only see their own bookings
- 💰 **Booking Logic (C#)** — Nightly totals computed from date range × price per night
- ✅ **Input Validation (Python)** — Numeric prompts re-ask until you actually type a number
- 💾 **In-Memory Storage** — `List<T>` in C# and Python lists stand in for a database — no persistence, no external dependencies

---

## 🛠️ Tech Stack

| Layer     | Technology                        |
|-----------|-----------------------------------|
| Languages | Python 3, C# (.NET)               |
| Runtime   | Python 3 interpreter, .NET SDK    |
| Storage   | In-memory lists (no persistence)  |
| Interface | Console / CLI                     |

**Repository breakdown:** `python/` — Product Management System · `C#/hotelProj/` — Hotel Silverstone Booking

---

## 🚀 Getting Started

### Prerequisites

- Python 3 (for the Python project)
- .NET SDK 10.0 or later (for the C# project)
- A terminal

### Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/JoaoLuzWork/ProgIntroClasses.git
   cd ProgIntroClasses
   ```

2. **Run the Python project — Product Management System**
   - No installation required
   - From the repo root, run:
   ```bash
   python3 python/managementProgram.py
   ```
   - Use the on-screen menu to add, list, search, edit or delete products

3. **Run the C# project — Hotel Silverstone**
   - Move into the project folder:
   ```bash
   cd "C#/hotelProj"
   ```
   - Build and run with the .NET CLI:
   ```bash
   dotnet run
   ```
   - Register a guest from the main menu, or log in as the seeded admin

4. **Read the detailed Hotel Silverstone docs**
   - The `C#/hotelProj/` folder has its own [`README.md`](./C%23/hotelProj/README.md) with the seed data, file-by-file breakdown and known limitations

---

## 🤝 Contributing

This is a personal learning project, but suggestions and feedback are always welcome. Feel free to open an issue or fork the repo.

---

## 👤 Author

**João Pedro Luz**

- GitHub: [@JoaoLuzWork](https://github.com/JoaoLuzWork)
- Email: joao.pedro.luz.work@gmail.com
- Location: Dublin, Ireland

---

## 📄 License

This project is open source and available for personal and educational use.
