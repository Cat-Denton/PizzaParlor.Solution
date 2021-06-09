
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