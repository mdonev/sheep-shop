# sheep-shop

Controller HerdsController with Views for listing and creating sheep name and born date (http://domain:port/herds/index)

Dynamic model class herd.cs with calculations for :

-age in standard sheep years 

-avg milk per day for every sheep

-total milk per sheep starting from day 0

-total skins of wool per sheep starting from day 0

-added validation for shave eligability and dying


Api Controller herdController giving services (http://domain:port/sheep-shop/herd)


--------------------------------------------------


Possible solution for User-Stories Sheep-1:

1.Formating xml with XmlSerializer using property attributes : XmlRoot, XmlElement, XmlAttribute... and
saving to xml file with  void save(){code..}


2.property integer T with calculations - Sum() of totalMilk, Sum() of skinWool

--------------------------------------------------

Possible solution for User-Stories Sheep-2:

-in ApiConfig changing routing to sheep-shop/{controller}/{T}
-herdController and stockController returning JSON
-making some kind of archive which day(T) how many milk and skins were available

--------------------------------------------------

Possible solution for User-Stories Sheep-3:

-order class with id,customer and order properties

-order controller with validation for milk and skins

--------------------------------------------------

Possible solution for User-Stories Bonus:

-shoping cart taking results from services and passing directly to Basket using AngularJS or KnockoutJS
