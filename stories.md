# Tabloid MVC Stories

> **Notes / Assumptions**  
> * Initial stories assume all users are admins. This is not a realistic approach, but it means students will have opportunity to do CRUD actions on every entity.
> * Stories prior to login/register assume a hard-coded user.
> * It is assumed that there is seed data for any story that requires data to exist, but is prioritized above stories that create data.

## Basic Authentication

As the Tabloid product owner, I would like all users to be authenticated in order to perform any activity in the system so that the system will be able to record which user created post, comment, etc... and EVENTUALLY restrict access to certain features based on user and user type permissions.

**Given** an unauthenticated user is in the Tabloid application  
**When** they click any link  
**Then** they should be prompted to login using their email address  

**Given** an unauthenticated user is viewing the login form  
**When** they enter an email address that matches an existing User Profile  
**Then** they should be authenticated into the system  
**And** they should be directed to the application home page  

**Given** an unauthenticated user is viewing the login form  
**When** they enter an email address that does not match an existing User Profile  
**Then** an error message should be displayed  
**And** the user should be given another change to enter a valid email address  

> **NOTE:** For the time being it is acceptable to treat all users as `admin` users. There is a future story about enforcing user permissions.

### Logout

As a user I would like to be able to logout of the system so that I can ensure that no one else who uses my computer will have access to my Tabloid account.

**Given** an authenticated user is in the Tabloid application  
**When** they select the `Logout` option from the menu  
**Then** they should be logged out of the system  
**And** they should be directed to the home page


## Posts

### View All Posts

As a reader, I would like to see a list of all the Posts so that I can choose a post that seems interesting to read.

**Given** the user is in the Tabloid application  
**When** they select the `Posts` menu option  
**Then** they should be directed to the Posts list page  
**And** each post in the list should display the title, author and category  
**And** the list should ONLY contain approved Posts  
**And** the list should ONLY contain Posts with a publication date that is in the past  
**And** the list should be in order of publication date with the most recent on top  


### View Current User's Posts

As an author, I would like to see a list of all the Posts I have written so that I can easily view, edit, delete, publish or unpublish them.

**Given** the user is in the Tabloid application  
**When** they select the `My Posts` menu option  
**Then** they should be directed to the "My Posts" list page  
**And** the page should display ALL the Posts authored by the logged-in user  
**And** each post in the list should display the title, author and category  
**And** the list should be in order of creation date with the most recent on top  

### View Post Details

As a reader, I would like to see the content of a Post so I can read it.

**Given** a user is viewing a list of Posts  
**When** they select a post to read  
**Then** they should be directed to a Post Detail page that shows the Post Details.

Post Details include:

* Title
* Header image (if exists)
* Content
* Publication date (MM/DD/YYYY)
* Author's Display Name

### Create a Post

As an author, I would like to be able to create Posts so I can share my thoughts with the world.

**Given** a user is in the app  
**When** they select the `New Post` menu option
**Then** they should be directed to a page with a form for creating a new post

**Given** the user has entered the relevant information for a Post
**When** they click the `Save` button  
**Then** the Post should be saved to the database  
**And** the creation datetime should be automatically set to the current date and time  
**And** the post should automatically be approved  
**And** the user should be recorded as the author of the Post  
**And** the user should be redirected to the new Post's details page

The "relevant information" for a Post is

* Title
* Content
* Category
* Header Image URL (optional)
* Publication Date (optional)

### Delete a Post

As an author I would like the ability to remove a post I have written so that I can prevent others from reading it when I decide it is no longer something I wish people to read.

**Given** an author is viewing a Post that they have written  
**When** they select the delete option  
**Then** they should be presented to confirm the deletion    

**Given** the author wishes to confirm the delete  
**When** they the select the option to confirm  
**Then** the Post should be removed from the system  
**And** the author should be directed back to the Post list  

**Given** the author decides not to confirm the delete  
**When** they the select the option to reject confirmation  
**Then** the Post should NOT be removed from the system  
**And** the author should be directed back to the Post details  

### Edit a Post

As a author I would like to be able to modify my Posts so that I can correct mistakes or add additional content.

**Given** the user is viewing the Post list  
**When** they select the option to edit an Post  
**Then** the user should be directed to a form and given the ability to change the Post's information  

**Given** the user is finished updating the Post information  
**When** they click the `Save` button  
**Then** the updated Post should be saved to the database  
**And** the user should be redirected to the new Post's details page

**Given** the user has decided not to edit the Post  
**When** they click the `Cancel` button  
**Then** the user should be redirected back to the list page

Editable Information

* Title
* Content
* Category
* Header Image URL (optional)
* Publication DateTime (optional)

---

## Categories

### View All Categories

As an admin I would like to see all the available categories so that I can choose to edit or delete one, or see that I should add a new one.

**Given** an admin is in the app  
**When** they select the `Category Management` link in the menu  
**Then** they should be directed to a page that lists all the Category names ordered alphabetically  

> **NOTE:** For the time being it is acceptable to treat all users as `admin` users. There is a future story about enforcing user permissions.

### Create a Category

As an admin I would like to be able to create a new category so that I can give authors the ability to better classify their posts.

**Given** an admin is on the Category list page  
**When** they select the `Create Category` button  
**Then** they should be directed to a form in which they can enter a new category name  

**Given** an admin has entered a Category name  
**When** they click the `Save` button  
**Then** a new category should be saved to the database  
**And** the admin should be directed to the Category list page

> **NOTE:** For the time being it is acceptable to treat all users as `admin` users. There is a future story about enforcing user permissions.

### Delete a Category

As an admin I would like to be able to delete a Category so that I can remove any that are not needed.

**Given** an admin is vising the list of Categories  
**When** they select the `Delete` option  
**Then** they should be prompted to confirm the deletion  

**Given** the admin wishes to confirm the delete  
**When** they the select the option to confirm  
**Then** the Category should be removed from the system  
**And** the admin should be directed back to the Category list  

**Given** the admin decides not to confirm the delete  
**When** they the select the option to reject confirmation  
**Then** the Category should NOT be removed from the system  
**And** the admin should be directed back to the Category list  

> **NOTE:** For the time being it is acceptable to treat all users as `admin` users. There is a future story about enforcing user permissions.

### Edit a Category

As an admin I would like to be able to modify a Category so that I can rephrase the name if I think of something more appropriate.

**Given** the user is viewing the Category list  
**When** they select the option to edit an Category  
**Then** the user should be directed to a form and given the ability to change the Category's name  

**Given** the user is finished updating the Category information  
**When** they click the `Save` button  
**Then** the updated Category should be saved to the database  
**And** the user should be redirected to the new Category List page  

**Given** the user has decided not to edit the Category  
**When** they click the `Cancel` button  
**Then** the user should be redirected back to the list page

> **NOTE:** For the time being it is acceptable to treat all users as `admin` users. There is a future story about enforcing user permissions.

---

## Tags

### View All Tags

As an admin I would like to see all the available Tags so that I can choose to edit or delete one, or see that I should add a new one.

**Given** an admin is in the app  
**When** they select the `Tag Management` link in the menu  
**Then** they should be directed to a page that lists all the Tag names ordered alphabetically  

> **NOTE:** For the time being it is acceptable to treat all users as `admin` users. There is a future story about enforcing user permissions.

### Create a Tag

As an admin I would like to be able to create a new Tag so that I can give authors the ability to better classify their posts.

**Given** an admin is on the Tag list page  
**When** they select the `Create Tag` button  
**Then** they should be directed to a form in which they can enter a new Tag name  

**Given** an admin has entered a Tag name  
**When** they click the `Save` button  
**Then** a new Tag should be saved to the database  
**And** the admin should be directed to the Tag list page

> **NOTE:** For the time being it is acceptable to treat all users as `admin` users. There is a future story about enforcing user permissions.

### Delete a Tag

As an admin I would like to be able to delete a Tag so that I can remove any that are not needed.

**Given** an admin is vising the list of Tags  
**When** they select the `Delete` option  
**Then** they should be prompted to confirm the deletion  

**Given** the admin wishes to confirm the delete  
**When** they the select the option to confirm  
**Then** the Tag should be removed from the system  
**And** the admin should be directed back to the Tag list  

**Given** the admin decides not to confirm the delete  
**When** they the select the option to reject confirmation  
**Then** the Tag should NOT be removed from the system  
**And** the admin should be directed back to the Tag list  

> **NOTE:** For the time being it is acceptable to treat all users as `admin` users. There is a future story about enforcing user permissions.

### Edit a Tag

As an admin I would like to be able to modify a Tag so that I can rephrase the name if I think of something more appropriate.

**Given** the user is viewing the Tag list  
**When** they select the option to edit an Tag  
**Then** the user should be directed to a form and given the ability to change the Tag's name  

**Given** the user is finished updating the Tag information  
**When** they click the `Save` button  
**Then** the updated Tag should be saved to the database  
**And** the user should be redirected to the new Tag List page  

**Given** the user has decided not to edit the Tag  
**When** they click the `Cancel` button  
**Then** the user should be redirected back to the list page  

> **NOTE:** For the time being it is acceptable to treat all users as `admin` users. There is a future story about enforcing user permissions.

### Add a Tag to a Post

As an author I would like to be able to associate one or more Tags with one of my Posts so that readers can easily see the Post topics at a glance.

**Given** the author is viewing Post details  
**When** they select the `Manage Tags` option  
**Then** they should be presented with a selection of Tags options to associate with the Post  

**Given** the author has selected the Tags they wish to associate with a Post  
**When** they click the `Save` button  
**Then** the association should be saved to the database  
**And** the user should be directed to the Post details page  
**And** the selected Tags should be displayed on the Post details page  

### Remove a Tag from a Post

As an author I would like to be able to unassociate one or more Tags from one of my Posts so that I can correct a mistakenly added Tag.

**Given** the author is viewing Post details  
**When** they select the `Manage Tags` option  
**Then** they should be presented with a selection of Tags options that are associated with the Post  

**Given** the author has selected the Tags they wish to remove from a Post  
**When** they click the `Save` button  
**Then** the association should be removed from the database  
**And** the user should be directed to the Post details page  
**And** the removed Tags should no longer be displayed on the Post details page  

---

## Comments

### View a Post's Comments

As a reader, I would like to see a list of all the Comments on a Post so that I can read and take part in the discussion on a particular Post.

**Given** the user is viewing the Details of a Post
**When** they select the `View Comments` button  
**Then** they should be directed to the Comments list page for the Post  
**And** the list should be in order of creation date with the most recent on top  
**And** the title of the related Post should be displayed at the top of the page  
**And** a link back to the Post should be available  

Display the following information for each Comment

* Subject
* Content
* Author's Display Name
* Creation date (MM/DD/YYYY)

### Create a Comment

As a commenter, I would like to be able to add a Comment to a Post so that I can take part in the discussion about a Post.

**Given** the user is viewing the Details of a Post
**When** they select the `Add Comment` menu option
**Then** they should be directed to a page with a form for creating a new Comment

**Given** the user has entered the relevant information for a Comment
**When** they click the `Save` button
**Then** the Comment should be saved to the database
**And** the creation datetime should be automatically set to the current date and time
**And** the user should be redirected to the new Comments list page for the related Post  

The "relevant information" for a Comment is

* Subject
* Content

### Delete a Comment

As a commenter I would like the ability to remove a Comment so that I have created so that I can prevent others from seeing it in the event that I regret what I said.

**Given** a user is vising the list of Comments  
**When** they select the `Delete` option  
**Then** they should be prompted to confirm the deletion  

**Given** the user wishes to confirm the delete  
**When** they the select the option to confirm  
**Then** the Comment should be removed from the system  
**And** the user should be directed back to the Comment list  

**Given** the user decides not to confirm the delete  
**When** they the select the option to reject confirmation  
**Then** the Comment should NOT be removed from the system  
**And** the user should be directed back to the Comment list  

### Edit a Comment

As a commenter I would like to be able to modify my Comments so that I can correct mistakes or add additional content.

**Given** the user is viewing the Comment list  
**When** they select the option to edit an Comment  
**Then** the user should be directed to a form and given the ability to change the Comment's information  

**Given** the user is finished updating the Comment information  
**When** they click the `Save` button  
**Then** the updated Comment should be saved to the database  
**And** the user should be redirected to the new Comment's details page

**Given** the user has decided not to edit the Comment  
**When** they click the `Cancel` button  
**Then** the user should be redirected back to the list page

Editable Information

* Subject
* Content

---

## User ProfileProfiles

### View All User Profiles

As an admin, I would like to see a list of all the User Profiles so that I can keep track of who is using the system.

**Given** the user is an admin in the Tabloid application  
**When** they select the `User Profiles` menu option  
**Then** they should be directed to the User Profiles list page  
**And** each user in the list should display the full name, the display name and the user type.
**And** the list should be in ordered alphabetically by user display name  

### View User Profile Details

As an admin, I would like to see the content of a User Profile so I can read it.

**Given** a user is viewing a list of User Profiles  
**When** they select a user
**Then** they should be directed to a User Profile Detail page  

User Profile Details include:

* Full name
* Avatar image (if exists, else use a default image)
* Display name
* Email
* Creation Date (MM/DD/YYYY)
* User Profile type

### Deactivate a User Profile

As an admin I would like the ability to deactivate a User Profile so that I can prevent unsavory characters from using the system.

**Given** an admin is vising the list of User Profiles  
**When** they select the `Deactivate` option  
**Then** they should be prompted to confirm deactivation  

**Given** the admin wishes to confirm the deactivation    
**When** they the select the option to confirm  
**Then** the User Profile should be deactivated in the system  
**And** the admin should be directed back to the User Profile list  

**Given** the admin decides not to confirm the deactivation    
**When** they the select the option to reject confirmation  
**Then** the User Profile should NOT be deactivated  
**And** the admin should be directed back to the User Profile list  

**Given** a user is deactivated  
**When** they try to login to the system  
**Then** the system should behave as if the user does not exist  

### Reactivate a User Profile

As an admin I would like the ability to reactivate a User Profile so that I can correct an mistaken User Profile deactivation

**Given** an admin is vising the list of User Profiles  
**When** they select the `View Deactivated` option  
**Then** they should see a list of deactivated User Profiles

**Given** an admin sees a User Profile they wish to reactivate  
**When** they select the `Reactivate` option  
**Then** the user should be reactivated  
**And** the user should have the same access to the system they had prior to being deactivated  

### Change a User Profile's Type

As an admin I would like to be able to change a User Profile's user type so that I can promote people to admin users and demote people to authors.

**Given** the user is viewing the User Profile list  
**When** they select the option to edit an User Profile  
**Then** the user should be directed to a form and given the ability to change the User Profile's user type.  

**Given** the user is finished updating the User Profile information  
**When** they click the `Save` button  
**Then** the updated User Profile should be saved to the database  
**And** the user should be redirected to the new User Profile list page.

**Given** the user has decided not to edit the User Profile  
**When** they click the `Cancel` button  
**And** the user should be redirected to the new User Profile list page.

### Prevent Loss of All Admins

As the Tabloid Product Owner, I would like to ensure at least one User Profile has a User Type of `admin` at all times, so that someone will always be available to administer the system.

**Given** only one User Profile has administrative rights  
**When** the user attempts to deactivate that last admain  
**Then** they should see an error message instructing them to make someone else an admin before the User Profile can be deactivated  

**Given** only one User Profile has administrative rights  
**When** the user attempts to change the User Type of the last admin  
**Then** they should see an error message instructing them to make someone else an admin before the User Profile can be changed  

---

## Authentication

### Register

As a potential user I would like to be able to create an account in the system so that I may use it's features.

**Given** a potential user wants to create an account in the system  
**When** they select the `Register` option from the menu  
**Then** they should be directed to a form where they are prompted to enter their User Profile information  

**Given** a potential user has entered their User Profile information  
**when** they click the `Register` button  
**Then** a new User Profile should be created in the database  
**And** the User Profile should have a user type of `Author`  
**And** the User Profile's creation datetime should be set to the current date end time  
**And** the user should be directed to the homepage  

The User Profile information is:

* First name
* Last name
* Display name
* Email

---

## Subscriptions

### Subscribe to a User's Posts

As a reader I would like to be able to subscribe to authors that I enjoy so that I can more easily find new Posts they have written.

**Given** A user is on a Post detail page  
**When** they select the option to subscribe to the Post's author's other Posts  
**Then** a Subscription should be created in the database  
**And** the Subscription's begin datetime should be set to the current time  

### View Subscribed Posts on Homepage

As a reader I would like to see a list of Posts written by authors I am subscribed to, so that I can more easily find Posts I may be interested in.

**Given** A user is on the homepage  
**When** the user has at least one Subscription  
**Then** they should see a list of Posts written by authors they are subscribed to  

### Unsubscribe to a User's Posts

As a reader I would like to unsubscribe from an author's Posts so that I won't see the Posts of author's I am no longer interested in reading.

**Given** a user is viewing the Post details of an author they are subscribed to  
**When** they select the option to unsubscribe to the author  
**Then** the Subscription end datetime should be updated with the current datetime  
**And** the system should behave as it did before the user had created the Subscription  

---

## Authorization

### Restrict User Profile Privileges

As the Tabloid application owner I would like  the privileges of users throughout the system to be restricted based on their user type so that unauthorized users cannot corrupt, delete or view data in the system.

The privileges of each user type are listed below:

> **NOTE:** Implementing the features outlined in this story will require updating some existing functionality in the system.

> **NOTE:** The dev team may find it useful to break this story into smaller stories in order to facilitate assigning tasks to team members and keeping track of the work.

> **NOTE:** Some of the privileges listed below refer to features that are further down in this backlog. When those future stories are worked, please refer back to this story for a description of the privileges.

> **NOTE:** The order of privileges is does not indicate their priority.

**Unauthenticated users can...**

* Register for an account
* Login to the system

**Authors can...**

* Login to the system
* Logout of the system
* View any active and published Posts
* View any Posts they have created
* Comment on a Post
* Edit Comments they created
* Delete Comments they created
* Add a Reaction to a Post
* Remove a Reaction from a Post
* Subscribe to a different User's Posts
* Unsubscribe from a user's Posts
* Write a new Post
* Publish a Post they have created
* Unpublish a Post they have created
* Edit a Post they have created
* Delete a Post they have created
* Add Tags to a Post they have created
* Remove Tags from a Post they have created
* Upload a Profile image
* Upload a Post Header image

**Admins can...**

* Do all the things Author users can do
* View any User Profile
* Deactivate a User Profile
* Change a User Profile's user type
* Add a Category
* Edit a Category
* Remove a Category
* Add a Tag
* Edit a Tag
* Remove a Tag
* Add a Reaction to the system
* Edit a Reaction in the system
* Remove a Reaction from the system
* Upload a Reaction image
* Delete any Post
* Delete any Comment

---

## Reactions

### Add a Reaction to a Post

As a reader I would like to demonstrate my feelings about a particular Post using the power of an image so that I don't have to think of any words to express myself.

**Given** a user is viewing a Post details page  
**When** the select a Reaction image  
**Then** a record should be added to the database denoting the user's Reaction to the Post  
**And** a count beside the Reaction image should be incremented  

### View Reactions on a Post

As an author I would like to see the various Reactions to my Post so that I can get a sense of readers' responses.

**Given** a user is viewing a Post details page  
**When** they look below the body of the Post  
**Then** they should see a row of Reaction images with a number beside each to indicate how many users have chosen that Reaction

> **NOTE:** Reaction counts should be visible to anyone who can view the Post.

---

## Images

### Upload User Profile Image

As a user I would like to be able to upload an avatar image so that I do not have to find an image online to link to.

### Upload Post Header Image

As an author I would like to be able to update a header image for a Post so that I do not have to find an image online to link to.

### Create New Reaction

As an admin I would like to be able to add a new Reaction so that I can increase the variety of Reactions available to users of the system.

---

## Post Approval

### Author Created Posts are initially Unapproved

As an admin I would like Posts written by non-admin users (a.k.a. "Authors") to be initially unapproved, so that authors are unable to publish any inappropriate Posts without oversight.

> **NOTE:** If an admin writes a Post it should be automatically approved.

### Admins Can Approve Posts

As an admin I would like the ability to approve Posts that I deem appropriate so that the system can provide quality content.

### Admins Can Un-approve Posts

As an admin I would like the ability to un-approve Posts in case I change my mind about the appropriateness of a Post.

---

## Finding Posts

### Search by Tag

As a reader I would like to be able to find Posts by Tag so that I can more easily find interesting Posts.

### List Posts by Category

As a reader I would like to see all posts in a particular category so that I can more easily find interesting Posts.

### List Posts by User Profile

As a reader I would like to be able to see all the Posts for a particular User Profile so that I can decide if I would like to subscribe to the user's Posts.


## Admin Management

------------------------------------------------------------------
### Two Admins to Deactivate or Demote

As the Tabloid Product Owner, I would like to require that two admins agree to deactivate another admin or to change an admin's user type.
