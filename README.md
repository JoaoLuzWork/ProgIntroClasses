python/ — Product Management System

A single-file inventory manager (managementProgram.py). A Product class holds id, name, description, brand, colour, price and quantity; a ProductsManagementSystem class keeps them in a list that stands in for a database.

From the menu you can add a product (rejecting ids that already exist), list everything, search by id or by name, edit one field or all of them at once, and delete by id. Numeric prompts go through a small helper that re-asks until you actually type a number.

Run it with Python 3 — there is nothing to install:

bash
python3 python/managementProgram.py
C#/ — Hotel Silverstone

A console hotel booking system (C#/hotelProj), and the larger of the two projects. It splits into five files — Program, User, Admin, Room and Bookings — with static lists in Program acting as the in-memory database.

There are two roles. Guests register, log in, browse available rooms, book one, then view, update or cancel their own bookings, and edit their profile. Admins get a wider menu: list every guest, room and booking, full room management, bookings on behalf of any guest, and registering another admin. Nightly totals are worked out from the date range and the room's price.

Needs the .NET SDK:

bash
cd "C#/hotelProj"
dotnet run

That folder has its own README.md with the seed data, a file-by-file breakdown and the known limitations.

Notes

Neither project saves anything — close the program and the data is gone. That is deliberate for the exercise: the lists are there to stand in for a database while the focus stays on the language itself.
