
Customer
* CREATE order - pick up or delivery
* View menu INDEX
* View only their order DETAILS and EDIT order

Staff
* Look at order INDEX & all order DETAILS
* Mark Order status (completed? delivered?)
* Look at menu INDEX and DETAILS
* EDIT/DELETE MenuItems


WHAT TO DO
1. Get rid of customer class / customer tables
2. Get rid of join tables/entities for CustomerOrder
3. Add properties to Order class
  * Customer info - name, phone number, address if it's a delivery
  * Pick up or delivery - IsDelivery
  * IsCompleted
4. Finish routes/views for Order
  * AddMenuItem
  * Finish Details
  * Index
    * MarkComplete
  * Edit and Delete Order
5. Finish routes/views for MenuItems
  * Edit and Delete MenuItems
6. Authentication and user roles
  * Two user roles: staff and customer
  * Staff should be able to see all orders, mark orders complete, mark orders delivered
  * Staff should be able to see, add, edit and delete menu items
  * Staff should be able to create new orders, see all orders, add or remove menu items from any order
  * Customers should be able to create new orders, see their own order, add or remove menu items from their order, should be able to edit order info until IsComplete == true
  * Customers should be able to see previous orders and re-order with a click of a button