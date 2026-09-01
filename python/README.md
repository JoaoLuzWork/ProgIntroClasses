# 🐍 Product Management System — Console Inventory Manager

A console-based inventory manager written in Python, built as part of an introductory programming course. It models a shop's product catalogue — add, list, search, edit and delete — with a plain Python list standing in for the database.

---

## 📖 About

Product Management System is a single-file, interactive Python program that lets you manage a shop's product catalogue from the command line. Products are modelled as objects with seven fields (id, name, description, brand, colour, price and quantity), and a manager class exposes the full CRUD lifecycle through a menu-driven interface.

The project was developed as part of an introductory programming course to practise core object-oriented programming concepts in Python, including classes, methods, list-based storage, input handling, and console-driven user interaction.

---

## 🛠️ Requirements

- Python 3 (any recent version)
- No third-party packages, no virtual environment needed

---

## 🚀 Running

```bash
python3 managementProgram.py
```

The app opens straight into the main menu and loops until you choose **Exit**:

```
=======Product Management System=======

Choose one of the options below:

1 - Add Product
2 - Display Products
3 - Search Product
4 - Edit Product
5 - Delete Product
6 - Exit
```

The catalogue starts empty — add a product first before the other options do anything.

---

## 📂 Project Structure

```
python/
└── managementProgram.py    Everything: both classes plus the main menu loop
```

Single-file project — no build output, no dependencies, no configuration.

---

## 🔧 How It Fits Together

**Two classes and a loop.**

`Product` is the record. It holds `id`, `name`, `description`, `brand_name`, `color`, `price` and `quantity`, and has one method, `display()`, which prints the product as a labelled block.

`ProductsManagementSystem` is the store. Its only state is `self.products_record`, a list of `Product` objects — the comment in the file calls it the **"fake DB"**. Every operation is a method on this class, and lookups go through two small helpers:

```python
def find_by_name(self, name)   # first product whose name matches
def find_by_id(self, id)       # first product whose id matches
```

`verify_id()` wraps `find_by_id` to answer "is this id taken?", and `get_int_input()` is a prompt helper that keeps re-asking until the input passes `isdigit()`.

At the bottom of the file a single `ProductsManagementSystem` is created and a `while True` loop reads a menu choice and dispatches to the matching method — this stands in for what would be a web front end in a real application.

---

## ✨ Features

### 📋 Main Menu

| # | Option           | Method                | What It Does                                                                                       |
| - | ---------------- | --------------------- | -------------------------------------------------------------------------------------------------- |
| 1 | Add Product      | `add_product()`       | Prompts for all seven fields and appends a new `Product`. Rejects an id that already exists.       |
| 2 | Display Products | `display_products()`  | Prints every product in the list.                                                                  |
| 3 | Search Product   | `search_product()`    | Sub-menu: find by id, or find by name.                                                             |
| 4 | Edit Product     | `edit_product()`      | Looks the product up by id, then a sub-menu picks one field to change — or option 8 to re-enter all of them. |
| 5 | Delete Product   | `del_product()`       | Removes the product with the given id.                                                             |
| 6 | Exit             | —                     | Breaks the main loop.                                                                              |

### 🔍 Search Behaviour

- Names are lowercased both when stored and when searched, so **"Kettle"** and **"kettle"** match
- Searches return the **first match only**

---

## ⚠️ Known Limitations

Worth knowing before extending it — most are natural next exercises.

- **No persistence.** The list lives in memory; closing the program discards the catalogue.
- **The input helper isn't used everywhere.** `get_int_input()` guards menu choices and ids, but price and quantity go straight through `float(input(...))` / `int(input(...))`, and so does the main menu's own `int(input(...))`. Typing a letter at any of those crashes the program with a `ValueError`.
- **"Edit all" skips its own validation.** Option 8 reads the new id with a bare `int(input(...))` and never calls `verify_id()`, so it can crash on bad input and create a duplicate id that the add path would have rejected.
- **Misleading messages.** Searching by name reports *"Invalid id, try again"* on a miss, and in `edit_product` an invalid field choice prints *"Invalid choice try again"* and then *"Invalid id try again"* immediately after, because that second line sits at the end of the loop body rather than inside the `else`.
- **A formatting slip.** `print(f"id changed to ",{id})` builds an f-string with no placeholder and passes a set as a second argument, so it prints `id changed to  {5}`. It wants to be `print(f"id changed to {id}")`.
- **An unreachable exit in the search sub-menu.** Anything other than 1 or 2 silently re-prints the search menu with no message and no way back to the main menu except a successful search.
- **Trailing semicolons.** Harmless, but not idiomatic Python — a habit carried over from C-style languages.

---

## 🔮 Possible Next Steps

- [ ] Route every numeric prompt through `get_int_input()`, and add a `get_float_input()` for price
- [ ] Give the search and edit sub-menus a "back" option and a message on invalid choices
- [ ] Save the catalogue to JSON on exit and reload it on start
- [ ] Let `find_by_name` return all matches rather than the first
- [ ] Replace `verify_id` with `return self.find_by_id(id) is not None`

---

## 👤 Author

**João Pedro Luz**

- GitHub: [@JoaoLuzWork](https://github.com/JoaoLuzWork)
- Email: <joao.pedro.luz.work@gmail.com>
- Location: Dublin, Ireland

---

## 📄 License

This project is open source and available for personal and educational use.
