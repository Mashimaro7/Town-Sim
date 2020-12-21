##Andy and Mark's Fun New Game!

Cute asthetic, simple design. 3D

###Gameworld Layout

- Round world, mostly flat. Maybe a few pieces of scenery. Drops off to the void at the edges

- Village centred on the map with houses and various utility and city buildings

- Start off with a couple houses and a town hall, and slowly add more houses and other buildings.

- Add decorative elements such as trees/shrubs to fill out the world

- Add lakes for aesthetic purposes, but could also be functional entities (villagers collect water?)

***Things to Figure Out***
- Should the buildings be places on designated build sites or should we have a road/footpath system of some sort that the buildings can be placed along?

- Is the world pre-populated with trees/bushes, water objects, or does the player get to add those in? Or maybe a bit of both?



###Gameplay

***Overall goal***
- Build your town by collecting resources and maintaining villager happiness.
- Happy villagers provide resources which are used to grow town.
- Emphasis on social system which results in more greater resource collection?


####Design

***Gameplay Loop:***
- Use resources to add buildings to the town
    - Build houses to attract villagers
    - Build certain social buildings to provide fun and more socializing opportunities
    - Other functional buildings (food, water)
- Collect resources from villagers
- Manage villager happiness by providing fun, food, water and social

***Gameplay Elements***

*Buildings*

- Build houses to increase villagers.
    - Number of houses adds to population cap.
    - Fancier houses are more expensive, but improve villager happiness?

- Resource Buildings/Nodes
    - Certain buildings or objects (like lakes and streams) allow villager to collect resources.
    - Lakes are separate objects and you can get water from them?

- Social Buildings
    - Build social buildings to provide fun and give villagers more chances to socialize

    
*Villagers*

- Have to maintain happiness by supplying food, fun, water, social.

- Provide money at a certain interval (taxes), and maybe a bonus amount dependent on average happiness (donations). 

- Collect resources from villagers
    - Collect by clicking on them when their collection timer is up
    - Have villagers donate additional resources to the city rejuvination fund when they are very happy. 
    - Have some sort of timeout on villagers who are consistenly very happy.


*Social System*
- Have a complex, proximity based social system
    - Villagers socialize at a certain chance when passing by eachother, or there will be buildings for socialization.
    - Villagers may pass eachother as they walk through town going about their duties, or they might go to a social building where they might spend a bit more time and socialize with a number of other villagers. 
        - Might need to have a timeout for villager pairs so that once a villager interacts with another, there is a minimum time that needs to pass before they can interact again.
            - Maybe this timeout is relationship base, better relationships have shorter timeouts?
        - When multiple villagers are in proximity, need a function to resolve who they interact with.
            - Based on time (did one villager get there first), relationship (is there a villager that the person likes better), timeout (villagers that the person has talked to quite recently should be excluded from the equation)
            - If a villager shows up and they have a significantly better relationship with that person than the first villager, should they be able to interrupt the interaction?

- Villagers also develop friendships or start to hate eachother, based on random chance.
    - The more they hate the lower the chance for them to socialize, and when they are nearby their happiness will drop.
    - On the contrary, if they are good friends, their happiness will increase!
    - Maybe each interaction has a chance to improve or worsen the relationship between the two villagers.
        - Chance is based on a calculation of likes and dislikes for each person
        - John likes exercise, art and also likes Peter, but dislikes vegetables and Marcy
        - Mordecai likes food and Marcy but dislikes art, Peter and vegetables
        - Calcuate something like: 

            - Take the union of both parties attributes:

            Union   | exercise | art | Peter | vegetables | Marcy | food 
            --------|----------|-----|-------|------------|-------|------
            John    |    1     |  1  |   1   |     -1     |   -1  |   0
            Mordecai|    0     | -1  |  -1   |     -1     |    1  |   1
            Result  |    0     | -1  |  -1   |      1     |   -1  |   0    

            - Score = 0 - 1 - 1 + 1 - 1 + 0 = Fondness score of -2 (we can call this score something else) 
            - The fondness score is simply multiplying each attribute, if they have the same like, that improves their score, if they feel opposite about something, that subtracts from their score, if there is something that one person likes/dislikes but the other person has no preference, then it doesn't contribute to the score.

            - Interaction result = (fondness score * some mod) + avg (M happiness, J happiness)
            - Interaction result = (      -2       *    2%   ) + avg( 80%, 30%) 
            = (-2 * 2%) + 55% = -4% + 55% = 51% chance of positive interaction

            - The interaction result is the average of the happiness of the two villagers plus the fondness score multiplied by some modifier. 
            - We will probably have to play around with these calculations once things are up and running.
        - Could potentially store the relationships of all villagers in a matrix so that we can quickly pull in those scores and then each villager's social circle would affect the interaction. Not if this would be beneficial but it could add some interesting behavior.
        - Each villager could probably keep track of their own basic likes
        
        class Villager {

            enum LikeCategory 
            {
                food,
                art,
                cats
            }

            // Could possibly use the nullable type of Boolean, then true would be like, false
            // would be dislike and null would be neutral, but I think Integer might be easier
            // to do math with.
            // Likes will be randomly set on Villager creation, and then will probably be static
            // after that.
            Dictionary<LikeCategory, Int or ?Boolean> likes;

            GetLikenessScore(Villager otherVillager);        
        }
            
