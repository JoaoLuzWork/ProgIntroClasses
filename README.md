📚 ProgIntroClasses

Coursework from my introduction to programming classes. Each folder is a small, self-contained console application built while learning a language — no frameworks, no database, no external packages. The point of each one is the fundamentals: classes and objects, lists as storage, menu-driven flow, and basic CRUD.

📖 About

This repository gathers the exercises and small projects I built while getting to grips with the core building blocks of programming. Both projects are console applications, written from scratch in their respective languages, and both use the same underlying idea: model the domain with classes, keep the data in a list that stands in for a database, and drive everything through a menu.

Neither project pulls in a framework or an external package — the point was to learn the languages, not the libraries.

📂 Repository Structure
ProgIntroClasses/
├── python/   Product Management System  — Python
└── C#/       Hotel Silverstone booking  — C# / .NET
Folder	Project	Language
python/	Product Management System	Python 3
C#/	Hotel Silverstone Booking	C# / .NET
🐍 python/ — Product Management System

A single-file inventory manager (managementProgram.py). A Product class holds id, name, description, brand, colour, price and quantity; a ProductsManagementSystem class keeps them in a list that stands in for a database.

From the menu you can:

➕ Add a product — rejecting ids that already exist
📋 List everything
🔍 Search by id or by name
✏️ Edit one field or all of them at once
🗑️ Delete by id

Numeric prompts go through a small helper that re-asks until you actually type a number.

▶️ Running

Run it with Python 3 — there is nothing to install:

bash
python3 python/managementProgram.py
🏨 C#/ — Hotel Silverstone

A console hotel booking system (C#/hotelProj), and the larger of the two projects. It splits into five files — Program, User, Admin, Room and Bookings — with static lists in Program acting as the in-memory database.

There are two roles:

👤 Guests — register, log in, browse available rooms, book one, then view, update or cancel their own bookings, and edit their profile.
🛡️ Admins — get a wider menu: list every guest, room and booking, full room management, bookings on behalf of any guest, and registering another admin.

Nightly totals are worked out from the date range and the room's price.

▶️ Running

Needs the .NET SDK:

bash
cd "C#/hotelProj"
dotnet run

📘 That folder has its own README.md with the seed data, a file-by-file breakdown and the known limitations.

📝 Notes

Neither project saves anything — close the program and the data is gone. That is deliberate for the exercise: the lists are there to stand in for a database while the focus stays on the language itself.

👤 Author

João Pedro Luz

GitHub: @JoaoLuzWork
Email: joao.pedro.luz.work@gmail.com
Location: Dublin, Ireland
📄 License

This project is open source and available for personal and educational use.
