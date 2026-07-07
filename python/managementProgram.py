#List of products is being used to represent a "class" called product that would be used to connect the program with the database info
class Product:

  def __init__(self, id, name, description, brand_name, color, price, quantity):
    self.id = id;
    self.name = name;
    self.description = description;
    self.brand_name = brand_name;
    self.color = color;
    self.price = price;
    self.quantity = quantity;

  def display(self):
    print(f"ID: {self.id} \nName: {self.name}\nDescription: {self.description} \nBrand: {self.brand_name}\nColor: {self.color}\nPrice: {self.price}\nQuantity: {self.quantity}\n\n")

class ProductsManagementSystem:

#contructor of the fake DB
  def __init__(self):
    self.products_record = []

#function to search in the list for any name equals to the input
  def find_by_name(self, name):
    for product in self.products_record:
        if product.name == name:
            return product
    return None

#function to search in the list for any id equals to the input
  def find_by_id(self, id):
    for product in self.products_record:
        if product.id == id:
            return product
    return None

#used to verify if the id alredy exits
  def verify_id(self, id):
    if self.find_by_id(id):
      return True
    else: return False

#used to check if the ids and choices received by the user  are numbers
  def get_int_input(self, prompt):
    while True:
        value = input(prompt)
        if value.isdigit():
            return int(value)
        print("Invalid input, numbers only!\n\n")

#Function to construct both list and regular product
  def add_product(self):

    #These are "properties" of my product's "class"
    id = self.get_int_input("Enter product id: ")
    if self.verify_id(id):
      print("Invalid, ID alredy exists, try again\n\n");
      return;
    name = input("Enter product name: ").lower();
    description = input("Enter product description: ");
    brand_name = input("Enter product brand name: ");
    color = input("Enter product color: ");
    price = float(input("Enter product price: "));
    quantity = int(input("Enter product quantity: "));

    product = Product(id,name,description,brand_name,color,price,quantity);
    self.products_record.append(product);

#Function to show what it is included in the "class"
  def display_products(self):
    print("\n\n=======Display Products=======\n\n");
    for product in self.products_record: product.display();

#Fuction that searchs for specific prodruct in the database
  def search_product(self):
    while True:
      print("\n\n=======Search Product=======\n\n");
      print("\nChoose one of the options below:\n\n1-Search by ID\n2-Search by Name\n");
      choice = self.get_int_input("Enter your choice: ");

      if choice == 1:
        id = self.get_int_input("\nEnter product id: ");
        product = self.find_by_id(id)
        if product:
            product.display()
            return;
        else:
             print("Invalid id, try again")

      elif choice == 2:
        name = input("\nEnter product name: ").lower();
        product = self.find_by_name(name)
        if product:
            product.display()
            return;
        else:
             print("Invalid id, try again")


#Fucntion to deal(edit) with the info in my fake database
  def edit_product(self):
    while True:

      print("\n\n=======Edit Product=======\n\n");
      id = self.get_int_input("Enter id of the product that you desire to modify: ");
      product = self.find_by_id(id)
      if product:
        print("\nNow choose what you want to change:\n\n1-Edit the ID\n2-Edit the Name\n3-Edit the description\n4-Edit the brand_name\n5-Edit the color\n6-Edit the price\n7-Edit the quantity\n8-Edit all");
        e_choice =  self.get_int_input("Enter your choice: ");
        if e_choice == 1:
          id = self.get_int_input("Enter new id: ");
          if self.verify_id(id):
            print("Invalid, ID alredy exists, try again\n\n");
            return;
          print(f"id changed to ",{id});
          product.id = id;
          return;
        elif e_choice == 2:
          product.name = input("Enter new name: ").lower();
          print(f"name changed to {product.name}");
          return;
        elif e_choice == 3:
          product.description = input("Enter new description: ");
          print(f"description changed to {product.description}");
          return;
        elif e_choice == 4:
          product.brand_name = input("Enter new brand name: ");
          print(f"brand_name changed to {product.brand_name}");
          return;
        elif e_choice == 5:
          product.color = input("Enter new color: ");
          print(f"color changed to {product.color}");
          return;
        elif e_choice == 6:
          product.price = float(input("Enter new price: "));
          print(f"price changed to {product.price }");
          return;
        elif e_choice == 7:
          product.quantity = int(input("Enter new quantity: "));
          print(f"quantity changed to {product.quantity}");
          return;
        elif e_choice == 8:
          product.id = int(input("Enter new id: "));
          product.name = input("Enter new name: ").lower();
          product.description = input("Enter new description: ");
          product.brand_name = input("Enter new brand name: ");
          product.color = input("Enter new color: ");
          product.price = float(input("Enter new price: "));
          product.quantity = int(input("Enter new quantity: "));
          print("All fields changed successfully");
          return;
        else: print("Invalid choice try again");
      print("Invalid id try again");

#Function to delete products, in a real database I would develop it furder to be able to delete specific info not just the whole thing
  def del_product(self):
      print("\n\n=======Delete Product=======\n\n");
      id = self.get_int_input("Enter id of the product that you desire to delete: ");
      product = self.find_by_id(id)
      if product:
          self.products_record.remove(product);
          print("Product deleted successfully");
          return;
      else:
        print("Invalid id try again")


manager = ProductsManagementSystem();

#this represents my "webapplication" or just a way to simulate a program tha interacts directly
while True:

  print("\n\n=======Product Management System=======");
  print("\nChoose one of the options below:\n");
  print("1-Add Product\n2-Display Products\n3-Search Product\n4-Edit Product\n5-Delete Product\n6-Exit");
  choice = int(input("\nEnter your choice: "));

  if choice == 1: manager.add_product();
  elif choice == 2: manager.display_products();
  elif choice == 3: manager.search_product();
  elif choice == 4: manager.edit_product();
  elif choice == 5: manager.del_product();
  elif choice == 6: break;
  else: print("Invalid choice try again");
