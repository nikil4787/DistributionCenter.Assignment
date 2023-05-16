Instructions on how to execute the code and view results

1.Start DsitributionCenter project (API Project)

2.Start DistrubutionCenter.console.app in the terminal, it would ask for the path.
3.Give full specified path of the xml file containing the information of the parcels.
4.Now it should deserialize the xml files and console app should call the Distribution API.
5.The Distrubution Api will classify the parcel as mail/regular/heavy and it would check if the insurance clearance is required.
6.If insurance clearlance is required it would be sent to the insurance department, otherwise it would be sent to corresponding parcel department.

Note :
 - Validation have been performed using fluent validation
 - Mediator pattern is used to decouple the controller and the business logic
 - The logic of department handlers is left empty , since its out of scope of the assignment
 - Unit testing has been performed for the distributioncenter api project , since its the only place with the business logic and their is no other functionality to test.
