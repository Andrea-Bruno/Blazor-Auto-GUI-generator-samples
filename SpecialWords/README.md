## Special Words (Basic logic)

Our concept is to create a powerful tool for the automatic front end dinner of applications without having to add the burden for the developer of having to learn convoluted and complicated mechanisms.
In practice, our tool allows anyone to speed up their work by 70% without having to acquire new professional skills.
Our implementation of special words also falls within this perspective, which are commonly used words that, if inserted in the description or in the name of the properties, make them take on particular characteristics.

### Special Words:

| Special Words  | type             | Placement           |
|----------------|------------------|---------------------|
| date           | DateTime, String | name or description |
| time           | DateTime, String | name or description |
| password       | String           | name or description |
| color          | String           | name or description |
| email, e-mail  | String           | name or description |
| tel, phone     | String           | name or description |
| qr             | String           | description         |
           
These keywords, if inserted in the description or in the name of the property, make the field in the GUI take on the connotation and appearance of the term they describe, which also determines its validation and the forcing of the user to insert the specific data type.

Notes on this example project: The code file that is rendered in the panel, whose entry appears in the side menu, is the one in the project folder called Panels. The example demonstrates several properties with one of the special words in the description. As you can see, the display of the property on the page takes on appropriate characteristics based on the context, thanks to the presence of the special word.
You can add other classes in the Panels folder to add new menu items and panels in the GUI that is the web page.