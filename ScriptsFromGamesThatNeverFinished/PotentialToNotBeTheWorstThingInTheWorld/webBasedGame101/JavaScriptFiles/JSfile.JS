
//LEGG SCRIPT I BUNNEN AV BODY!! DA LESES HTML FØRST

var mainImage = document.getElementById("MainPictureID");
var chatLogRef = document.getElementById("chatLog");
/*document.getElementById("MainPictureID").src="./asstes/house_in_the_woods.jpg"; */

/*mainImage.src="./asstes/house_in_the_woods.jpg" */

function showImage2()
{
    document.getElementById("MainPictureID").src="./assets/green_forest_1.jpg";
}

function showImage3()
{
    document.getElementById("MainPictureID").src="./assets/hero_helmet.png";
}

function Button1()
{
    switch (currentState){
        case "GS":
            startAdventure();
            break;
        case "AP":
            startFight();   // should start a journey that contains 2-4 fights, with possibility to short rest on trip, or rapid fights.
            break;
        case "SUBP":
            console.log("i is SUBP.");
            break;
        case "BP":
            if(isHeroTurn == true)
            {
                enemyTakeDamage(heroDamage);
                
                isHeroTurn = false;
                battlePhase();
            }
            break;
        case "BRP":
            console.log("i is BRP.");
            break;
        case "TP":
            startShop();
            break;
        case "SP":
            //buyPhase();
            startShopBuy();
            break;
        case "IP":
            //full rest cost 40
            let roomCost = innCost;
            if(heroCurrentGold >= roomCost)
            {
                lootGain(-roomCost, "goldLootID")
                heroTakeDamage(-heroMaxHealth);
            }
            
            break;
        case "BS":
            //BS  //Sword
            ShopManager(-swordCost, "swordLevelLootID", 1, true);
            break;
        case "SPBuy":
            ShopManager(-10, "potionLootID", 1, true); // Cost, item, amount, isBuying
            break;
        case "SPSell":
            ShopManager(3, "potionLootID", -1, false); // Cost, item, amount, isBuying
            break;
        default: 
            console.log("i is something else");
            break;
        }
}

function Button2()
{
    switch (currentState){
        case "GS":
            startAdventure();
            break;
        case "AP":
            heroRest(); // change to REST
            swapButtonFunctionality();
            updateDisplayedHeroStats();
            break;
        case "SUBP":
            console.log("i is SUBP.");
            break;
        case "BP":
         //use potion
         if(isHeroTurn == true)
         {
            if (heroCurrentPotions > 0){            
                let potionHealing = -5;
                heroTakeDamage(potionHealing);
                heroCurrentPotions -= 1;
                calculateHeroStats();
                isHeroTurn = false;
                battlePhase();
            }
         }
            break;
        case "BRP":
            console.log("i is BRP.");
            break;
        case "TP":
            startInn();
            console.log(" i is INN.");
            break;
        case "SP":
            startShopSell();
            break;
        case "IP":
            let roomCost = (innCost / 2);
            if(heroCurrentGold >= roomCost)
            {
                lootGain(-roomCost, "goldLootID")
                heroTakeDamage(-(heroMaxHealth / 2));
            }
            break;
        case "BS":
            //BS //Armour
            ShopManager(-armourCost, "armourLevelLootID", 1, true);
            break;
        case "SPBuy":
            ShopManager(-30, "campingEquipmentLootID", 1, true) // Cost, item, amount, isBuying
            break;
        case "SPSell":
            ShopManager(10, "campingEquipmentLootID", -1, false) // Cost, item, amount, isBuying
            break;
        default: 
            console.log("i is something else");
            break;
        }
}

function Button3()
{
    switch (currentState) 
    {
        case "GS":
            startAdventure();
            break;
        case "AP":
            goTown();
            console.log("i is Town.");
            break;
        case "BP":
          retreatFromCombat();
          mainImage.src="./assets/green_forest_1.jpg";
            console.log("Retreat");
            break;
        case "TP":
            startBlackSmith();
            console.log(" i is BlackSmith.");
            break;
        case "SP":
            console.log("buying pouch");
            ShopManager(-goldPouchCost, "goldPouchLevelLootID", 1 , true);
            break;
        case "IP":
            let roomCost = (innCost / 4);
            if(heroCurrentGold >= roomCost)
            {
                lootGain(-roomCost, "goldLootID")
                heroTakeDamage(-(heroMaxHealth / 4));
            }
            break;
        case "BS":
            //BS // Shield
            ShopManager(-shieldCost, "shieldLevelLootID", 1, true);
            break;
        case "SPBuy":
            ShopManager(-10, "arrowLootID", 5, true) // Cost, item, amount, isBuying
            break;
        case "SPSell":
            ShopManager(5, "arrowLootID", -5, false) // Cost, item, amount, isBuying
            break;
        default: 
            console.log("i is something else");
            break;
    }
}

function Button4()
{
    switch (currentState) 
    {
        case "GS":
            /*createEnemies("hob-Gob", 1, 10, 1, 5, 5) // REMOVE
            console.log(enemy.enemyName);*/ 
            startAdventure();
            break;
        case "AP":
            console.log("i is AP.");
            break;
        case "SUBP":
            console.log("i is SUBP.");
            break;
        case "BP":
            console.log("i is BP.");
            break;
        case "BRP":
            console.log("i is BRP.");
            break;
        case "TP":
            startAdventure();
            mainImage.src="./assets/green_forest_1.jpg";
            break;
        case "SP":
            goTown();
            break;
        case "IP":
            goTown();
            break;
        case "BS":
            goTown();
            break;
        case "SPBuy":
            startShop();
            break;
        case "SPSell":
            startShop();
            break;
        default: 
            console.log("i is something else");
            break;
    }
}

//let heroHPD = document.getElementById("heroHealthDisplay");

//let plet = document.getElementById("pId");

/*
GameManager*
//Controlls logic for fight and chooses what functions run when
actions happen.
STARTNEW(), LOGIC(), CONTINUE(), FINNISH(), RESULT()
// BOOLS,  INCOMBAT, OUTOFCOMBAT
// AILMENTS?
//GAMECLOCK/ 1 full round 
*/

// XXXXXXX letIABLES FOR SCRIPT XXXXXXX //
let currentState = "GS"; 
// GameStart("GS"),
// AdventuringPhase("AP"),
// SettingUpBattlePhase("SUBP"),
// BattlePhase("BP"),
// battleResultPhase("BRP"),
// TownPhase("TP")
// SHOP("SP")
//INN ("IP")
//BlackSmith("BS")

// ADD INN, SHOP, BS and Upgrade?

let isHeroTurn = true; // change this depending on hero and enemy level

// XXXXXXX letIABLES FOR ENEMY XXXXXXX //


//change so all objects are instantiated directly into array, and copy from list to make current enemy(thereby not changing "base-enemy");
let goblin = {
    name: "Hob-Gob",
    maxHealth: 0,
    maxHealthBase: 5,
    currentHealth: 0,
    damage: 0,
    baseDamage: 2,
    maxLevel: 2,
    currentLevel: 0,
    maxPotions: 0,
    potions: 0,
    goldLoot: 5,
    arrowLoot: 2,
    experienceLoot: 10,
    isDead : false,
    givenLoot: false
    
}

let goblin1 = {
    name: "Goblin",
    maxHealth: 0,
    maxHealthBase: 10,
    currentHealth: 0,
    damage: 0,
    baseDamage: 4,
    maxLevel: 2,
    currentLevel: 0,
    maxPotions: 0,
    potions: 0,
    goldLoot: 5,
    arrowLoot: 2,
    experienceLoot: 10,
    isDead: false,
    givenLoot: false
}

let enemyArray = [
    goblin,
    goblin1
]

let testEnemyArray = [
    goblin = {
        name: "Hob-Gob",
        maxHealth: 0,
        maxHealthBase: 5,
        currentHealth: 0,
        damage: 0,
        baseDamage: 1,
        maxLevel: 2,
        currentLevel: 0,
        maxPotions: 0,
        potions: 0,
        goldLoot: 5,
        arrowLoot: 2,
        experienceLoot: 10,
        isDead : false,
        givenLoot: false
        
    },
     goblin1 = {
        name: "Goblin",
        maxHealth: 0,
        maxHealthBase: 10,
        currentHealth: 0,
        damage: 0,
        baseDamage: 2,
        maxLevel: 2,
        currentLevel: 0,
        maxPotions: 0,
        potions: 0,
        goldLoot: 5,
        arrowLoot: 2,
        experienceLoot: 10,
        isDead: false,
        givenLoot: false
    }
]


let enemyName;
let enemyMaxHealth;
let enemyCurrentHealth;
let enemyDamage;
let enemyMaxLevel = 2;
let enemyCurrentLevel;
let enemyIsDead;
let enemyGivenLoot;


// XXXXXXX letIABLES FOR HERO XXXXXXX //
//can be a object
let heroMaxHealth;
let heroCurrentHealth;
let heroDamage;
let heroMaxLevel;//const heroMaxLevel = 20;
let heroCurrentLevel;
let heroMaxExperience;
let heroCurrentExperience;
let heroIsDead = false;

// XXXXXXX letIABLES FOR RESOURCES XXXXXXX //
//HERO RESOURCES
let heroMaxGold;
let heroCurrentGold;
let maxGoldPouchLevel;
let currentGoldPouchLevel;
let goldPouchCost;
let heroMaxPotions;
let heroCurrentPotions;
let heroMaxArrows;
let heroCurrentArrows;
let heroCurrentCampingEquipment;
let heroMaxCampingEquipment;
//Enemy Resources
let enemyMaxPotions;
let enemyCurrentPotions;
let enemyArrowLoot;
let enemyGoldLoot;
let enemyExperienceLoot;
//TOWN "VARIABLES"
let innCost = 40; //change so that can be different
let currentSwordLevel;
let maxSwordLevel;
let currentArmourLevel; 
let maxArmourLevel;
let currentShieldLevel;
let maxShieldLevel;
let swordCost; // change so that can be different ( 40 * currentSwordLevel )
let armourCost = 40; // change so that can be different
let shieldCost = 40; // change so that can be different


// BATTLE letIABLES


function GameManager()
{
    //START
    stateChanged();
}

function jsSwitchCase()
{ 
    switch (currentState) 
    {
        case "GS":
            console.log("i is GS");
            break;
        case "AP":
            console.log("i is AP.");
            break;
        case "SUBP":
            console.log("i is SUBP.");
            break;
        case "BP":
            console.log("i is BP.");
            break;
        case "BRP":
            console.log("i is BRP.");
            break;
        case "TP":
            console.log(" i is TP.");
            break;
        case "SP":
            //SHOP
            break;
        case "IP":
            //INN
            break;
        case "BS":
            //BS
            break;
        case "SPBuy":
            break;
        case "SPSell":
            break;
        default: 
            console.log("i is something else");
            break;
    }
}

function swapButtonFunctionality()
{
    //different button options depending on phase?
    //switch case changing button "text" depending on phase
    switch (currentState){
    case "GS":
        document.getElementById("button1").innerHTML = "Start Adventure";
        document.getElementById("button2").innerHTML = "Start Adventure";
        document.getElementById("button3").innerHTML = "Start Adventure";
        document.getElementById("button4").innerHTML = "Start Adventure";
        break;
    case "AP":
        document.getElementById("button1").innerHTML = "Fight Goblin";
        document.getElementById("button2").innerHTML = `rest ${heroCurrentCampingEquipment}/${heroMaxCampingEquipment}`;
        document.getElementById("button3").innerHTML = "Go To Town";
        document.getElementById("button4").innerHTML = "Options";
        break;
    case "SUBP":
        console.log("i is SUBP.");
        break;
    case "BP":
        document.getElementById("button1").innerHTML = "Attack";
        document.getElementById("button2").innerHTML = "Use Potion";
        document.getElementById("button3").innerHTML = "Retreat";
        document.getElementById("button4").innerHTML = "Options";
        break;
    case "BRP":
        console.log("i is BRP.");
        break;
    case "TP":
        document.getElementById("button1").innerHTML = "Town SHOP";
        document.getElementById("button2").innerHTML = "Town INN";
        document.getElementById("button3").innerHTML = "Blacksmith";
        document.getElementById("button4").innerHTML = "Adventure";
        break;
    case "SP":
        document.getElementById("button1").innerHTML = "BUY";
        document.getElementById("button2").innerHTML = "SELL";
        document.getElementById("button3").innerHTML = `GoldPouch(${currentGoldPouchLevel}), Cost: ${goldPouchCost}`;
        document.getElementById("button4").innerHTML = "Back";
        break;
    case "IP":
        document.getElementById("button1").innerHTML = `Best Room, cost: ${innCost}`;
        document.getElementById("button2").innerHTML = `Mediocre Room, cost: ${(innCost / 2)}`;
        document.getElementById("button3").innerHTML = `Cupboard: cost: ${(innCost / 4)}`;
        document.getElementById("button4").innerHTML = "Back";
        break;
    case "BS":
        document.getElementById("button1").innerHTML = `Upgrade Sword(${currentSwordLevel}), cost: ${swordCost}`;
        document.getElementById("button2").innerHTML = `Upgrade Armour(${currentArmourLevel}), cost ${armourCost}`;
        document.getElementById("button3").innerHTML = `Upgrade Shield(${currentShieldLevel}), cost ${shieldCost}`;
        document.getElementById("button4").innerHTML = "Back";
        break;
    case "SPBuy":
        document.getElementById("button1").innerHTML = `buy potion, cost: 10`; //can change to changeable value later
        document.getElementById("button2").innerHTML = `buy campingEquipment, cost: 30`;
        document.getElementById("button3").innerHTML = `buy 5 arrows, cost: 10`;
        document.getElementById("button4").innerHTML = "Back";
        break;
    case "SPSell":
        document.getElementById("button1").innerHTML = `sell potion, get: 3`; //can change to changeable value later
        document.getElementById("button2").innerHTML = `sell campingEquipment, get: 10`;
        document.getElementById("button3").innerHTML = `sell 5 arrows, get: 5`;
        document.getElementById("button4").innerHTML = "Back";
        break;
    default: 
        console.log("i is something else");
        break;
    }
}

function calculateEnemyStats() //Do at start of each battle and each "action"?
{
    switch (currentState) 
    {
        case "AP":
           //Preload a enemy? //Nah will make object and just copy them over
            break;
        case "SUBP":
            enemyArray[0].currentLevel = 1; // Add gimmic
            enemyMaxStats();
            enemyArray[0].currentHealth = enemyArray[0].maxHealth;
            enemyArray[0].potions = enemyArray[0].maxPotions;
            enemyArray[0].isDead = false;
            enemyArray[0].givenLoot = false; 
            break;
        case "BP":
             // Update stats
            break;
        case "BRP":
             //Make sure enemy is dead and calculate loot?
            break;
    }
}


function retreatFromCombat()
{
    EnemyAI();
    resetDisplayedEnemyStats();
    currentState = "AP";
    stateChanged();

}

function calculateHeroStats() //Do after each "action?" AND Battle
{
    switch (currentState) 
    {
        case "GS":
            heroMaxLevel = 20;
            heroCurrentLevel = 1;
            currentGoldPouchLevel = 0;
            currentSwordLevel = 0;
            currentShieldLevel  = 0;
            currentArmourLevel = 0;
            heroMaxStats();
            heroCurrentExperience = 0;
            heroCurrentHealth = heroMaxHealth;
            heroDamage = 2 + (1 * heroCurrentLevel) + (1 * currentSwordLevel);
            heroCurrentGold  = 0;
            heroCurrentCampingEquipment = 1;
            swordCost = 20 + ( 10 * currentSwordLevel);
            shieldCost = 20 + (10 * currentShieldLevel);
            armourCost = 20 + (10 * currentShieldLevel);
            goldPouchCost = heroMaxGold;
            heroIsDead = false;
            break;

        default: 
        swordCost = 20 + ( 10 * currentSwordLevel);
        shieldCost = 20 + (10 * currentShieldLevel);
        armourCost = 20 + (10 * currentArmourLevel);
        heroDamage = 2 + (1 * heroCurrentLevel) + (1 * currentSwordLevel);
        heroMaxHealth = (15 + (5 * heroCurrentLevel) + (5 * currentArmourLevel) + (5 * currentShieldLevel));
        goldPouchCost = heroMaxGold;
        break;
    }
}

function countResources() //Do after each battle, and each "action?"
{
    switch (currentState) 
    {
        case "GS":
            heroCurrentPotions = 0;
            heroCurrentArrows = 0;
            //Instantiate Resources
        case "BP":
            // Manage resources during fight
            break;
        case "BRP":
            //Calculate loot
            break;
        case "TP":
            // Stock up on resources?
        case "SP":
            //SHOP
            break;
        case "IP":
            //INN
            break;
        case "BS":
            //BS
            break;
    }
}

function EnemyAI()
{
    if (enemyArray[0].currentHealth <= (enemyArray[0].maxHealth/2) && enemyArray[0].potions != 0)
    {
        enemyTakeDamage(-5); //heal for 5
        enemyArray[0].potions -= 1;
        chatLogRef.innerHTML += `${enemyArray[0].name} used a potion and healed for : 5 HP`;
    }
    else 
    {
        heroTakeDamage(enemyArray[0].damage);
        chatLogRef.innerHTML += `${enemyArray[0].name} attacked you for ${enemyArray[0].damage}`;
        console.log(`enemy damage: ${enemyArray[0].damage}`);
    }
    isHeroTurn = true;


}

function heroMaxStats() // Calculate new MAX stats after gaining new level
{
    heroMaxExperience = 50 + (10 * heroCurrentLevel);
    heroMaxHealth = (15 + (5 * heroCurrentLevel) + (5 * currentArmourLevel) + (5 * currentShieldLevel));
    heroMaxPotions = heroCurrentLevel;
    heroMaxArrows = 10 + (5 * heroCurrentLevel);
    heroDamage = 2 + (1 * heroCurrentLevel) + (1 * currentSwordLevel);
    heroMaxGold = 25 + ( 5 *currentGoldPouchLevel);
    heroMaxCampingEquipment = 2;
    maxGoldPouchLevel = 20;
    maxSwordLevel = 10;
    maxShieldLevel  = 10;
    maxArmourLevel = 10;
}

function enemyMaxStats()
{
    enemyName = "hobGob"; // Remove
    enemyMaxHealth = (5 + (5 * enemyCurrentLevel)); // Same as below. cann remove
    console.log(enemyArray[0].maxHealth);
    enemyArray[0].maxHealth = (5 + (5 * enemyArray[0].currentLevel)); // same as above
    console.log(enemyArray[0].maxHealth);
    enemyDamage = (2 * enemyCurrentLevel); // Same as below REMOVE 
    enemyArray[0].damage = (enemyArray[0].baseDamage * enemyArray[0].currentLevel); // Same as above
    console.log(`damage:${enemyArray[0].damage} basedamage${enemyArray[0].baseDamage} level${enemyArray[0].currentLevel}`);
    enemyMaxPotions = (enemyCurrentLevel); // Same as Below REMOVE
    enemyArray[0].maxPotions = (enemyArray[0].currentLevel); // Same as above

}

function experienceGain(experience) //gain experience
{

    if( heroCurrentLevel < 20)
    {
        let levelDifference = (heroCurrentLevel - enemyArray[0].currentLevel);
        if (levelDifference < 4)
        {
            console.log("level diff " + levelDifference);
            if (levelDifference <= 0){
                heroCurrentExperience += experience;
            }
            else
            {
                heroCurrentExperience += Math.round((experience / levelDifference)) ;
            }
            if (heroCurrentExperience >= heroMaxExperience)
            {
    
                heroCurrentExperience -= heroMaxExperience;      
                heroCurrentLevel += 1;
                heroMaxStats();
                heroCurrentHealth = heroMaxHealth;
            }
        }
        heroMaxStats();
    }   
}

function testGoldGain(loot)
{
    if ((heroCurrentGold + loot) >= heroMaxGold )
    {
        heroCurrentGold = heroMaxGold;
    }else
    {
        heroCurrentGold += loot;
    }
}

function lootGain(loot, lootID) //unopimal loot system, that is expandable to a sertain degree
{
    switch (lootID)
    {
        case "goldLootID": 
            //testGoldGain(loot);
            if ((heroCurrentGold + loot) >= heroMaxGold )
            {
                heroCurrentGold = heroMaxGold;
            }else
            {
                heroCurrentGold += loot;
            }
            
            break;
        case "arrowLootID": // lootID 2 is Arrows
            if((heroCurrentArrows + loot) >= heroMaxArrows)
            {
                heroCurrentArrows = heroMaxArrows
            }else
            {
                heroCurrentArrows += loot;
                console.log(`added ${loot} to ${lootID} at ${heroCurrentArrows}`);
            }

            break;
        default:
            alert(`somehow we couldn't add ${loot} to ${lootID}`);
            break;
    }
}

// SHOP SHOULD BE REDEFINED. THIS IS BARELY BETTER THAN HARDCODING
function ShopManager(gold, item, amount, bool)
{
    let isBuying = bool;
    if (((heroCurrentGold + gold) >= 0 && bool == true) || ((heroCurrentGold) != heroMaxGold) && bool == false)
    {
        StartBuying(gold, item, amount, bool);
    }
    else
    {
    alert(`Bool is ${bool}, and that ait ok my lad`);
    }
}

function StartBuying(gold, item, amount, bool)
{
    let isBuying = bool;
        switch (item)
        {
            case "arrowLootID":
                finnishBuying(heroCurrentArrows, heroMaxArrows , "arrowLootID", gold, amount, bool);
                break;
            case "potionLootID":
                finnishBuying(heroCurrentPotions, heroMaxPotions , "potionLootID", gold, amount, bool);
                break;
            case "campingEquipmentLootID":
                finnishBuying(heroCurrentCampingEquipment, heroMaxCampingEquipment , "campingEquipmentLootID", gold, amount, bool);
                break;
            case "goldPouchLevelLootID":
                finnishBuying(currentGoldPouchLevel, maxGoldPouchLevel, "goldPouchLevelLootID", gold, amount, bool)
                break;
            case "swordLevelLootID":
                finnishBuying(currentSwordLevel, maxSwordLevel, "swordLevelLootID", gold, amount, bool);
                break;
            case "shieldLevelLootID":
                finnishBuying(currentShieldLevel, maxShieldLevel, "shieldLevelLootID", gold, amount, bool);
                break;
            case "armourLevelLootID":
                finnishBuying(currentArmourLevel, maxArmourLevel, "armourLevelLootID", gold, amount, bool);
                break;
        }
}

function finnishBuying(heroCurrentItem, heroMaxItem, lootID ,gold, amount, bool)
{
    console.log(`heroCurrentItem: ${lootID}`);
    if((heroCurrentItem >= heroMaxItem && bool == true) || (heroCurrentItem < -amount && bool == false)) // shouldn't need the > here, but just in case I guess
    {
        console.log("You are allready at max or min potions");
    }else
    {
        switch (lootID)
        {
        case "arrowLootID":
            heroCurrentArrows += amount;
            break;
        case "potionLootID":
            heroCurrentPotions += amount;
            break;
        case "campingEquipmentLootID":
            heroCurrentCampingEquipment += amount;
            break;
        case "goldPouchLevelLootID":
            currentGoldPouchLevel += amount;
            heroMaxGold = 25 + ( 5 *currentGoldPouchLevel);
            break;
        case "swordLevelLootID":
            currentSwordLevel += amount;
            heroDamage = 2 + (1 * heroCurrentLevel) + (1 * currentSwordLevel); // lag en "update max stats som fungera enn den som va."
            console.log(currentSwordLevel);
            break;
        case "shieldLevelLootID":
            currentShieldLevel += amount;
            heroMaxHealth = (15 + (5 * heroCurrentLevel) + (5 * currentArmourLevel) + (5 * currentShieldLevel));
            break;
        case "armourLevelLootID":
            currentArmourLevel += amount;
            heroMaxHealth = (15 + (5 * heroCurrentLevel) + (5 * currentArmourLevel) + (5 * currentShieldLevel));
            break;
        }
        console.log(gold);
        calculateHeroStats();
        swapButtonFunctionality();
        testGoldGain(gold);
        updateDisplayedHeroStats();
    }
}
function updateDisplayedHeroStats()
{
    document.getElementById("heroHealthDisplay").innerHTML = `Hero Health: ${heroCurrentHealth} / ${heroMaxHealth}`;
    document.getElementById("heroDamageDisplay").innerHTML = `Hero Damage: ${heroDamage}`;
    document.getElementById("heroLevelDisplay").innerHTML = `Hero Level: ${heroCurrentLevel}/ ${heroMaxLevel}`;
    document.getElementById("heroExperienceDisplay").innerHTML = `Hero Experience: ${heroCurrentExperience}/${heroMaxExperience}`;
    document.getElementById("heroPotionDisplay").innerHTML = `Hero Potions: ${heroCurrentPotions}/${heroMaxPotions}`;
    document.getElementById("heroArrowDisplay").innerHTML = `Hero Arrows: ${heroCurrentArrows}/${heroMaxArrows}`;
    document.getElementById("heroGoldDisplay").innerHTML = `Hero Gold: ${heroCurrentGold}/${heroMaxGold}`;
}

function updateDisplayedEnemyStats()
{
    document.getElementById("enemyNameDisplay").innerHTML = `Enemy Name: ${enemyArray[0].name}`;
    document.getElementById("enemyHealthDisplay").innerHTML = `Enemy Health: ${enemyArray[0].currentHealth}/${enemyArray[0].maxHealth}`;
    document.getElementById("enemyDamageDisplay").innerHTML = `Enemy Damage: ${enemyArray[0].damage}`;
    document.getElementById("enemyLevelDisplay").innerHTML = `Enemy Level: ${enemyArray[0].currentLevel}`;
    document.getElementById("enemyPotionDisplay").innerHTML = `Enemy Potions: ${enemyArray[0].potions}`;
}

function resetDisplayedEnemyStats()
{

    document.getElementById("enemyNameDisplay").innerHTML = `Name: `;
    document.getElementById("enemyHealthDisplay").innerHTML = `Enemy Health:`;
    document.getElementById("enemyDamageDisplay").innerHTML = `Enemy Damage:`;
    document.getElementById("enemyLevelDisplay").innerHTML = `Enemy Level`;
    document.getElementById("enemyPotionDisplay").innerHTML = `Enemy Potions:`;
}

function startAdventure()
{
    currentState = "AP";
    stateChanged();
}

function startFight()
{
    currentState = "SUBP";
    stateChanged();
}

function startShop()
{
    currentState = "SP";
    stateChanged();
}

function startShopBuy()
{
    currentState = "SPBuy"
    stateChanged();
}

function startShopSell()
{
    currentState = "SPSell";
    stateChanged();
}

function startInn()
{
    currentState = "IP";
    stateChanged();
}

function startBlackSmith()
{
    currentState = "BS";
    stateChanged();
}

function goTown()
{
    currentState = "TP";
    mainImage.src="/assets/house_in_the_woods.jpg";
    chatLogRef.innerHTML = `You went entered Town`;
    stateChanged();
}

function createEnemy()
{
    calculateEnemyStats();
    updateDisplayedEnemyStats();
    mainImage.src= "/assets/encounter_goblin.jpg";
    chatLogRef.innerHTML = `You encountered ${enemyArray[0].name}`;
    currentState = "BP";
    stateChanged();
}

function enemyTakeDamage(damage)
{
    enemyArray[0].currentHealth -= damage;
    chatLogRef.innerHTML += `<p>${enemyArray[0].name} took ${heroDamage} damage</p>`
    updateDisplayedEnemyStats()

    if(enemyArray[0].currentHealth <= 0)
    {
        enemyArray[0].currentHealth = 0;
        enemyArray[0].isDead = true;
        chatLogRef.innerHTML = `${enemyArray[0].name} died! </br>`;
        mainImage.src="./assets/green_forest_1.jpg";
    }
}

function heroRest()
{
    if(heroCurrentCampingEquipment > 0)
    {
        heroCurrentCampingEquipment -= 1;
        heroTakeDamage(-(heroMaxHealth/2));
    }
}

function heroTakeDamage(damage)
{
    heroCurrentHealth -= damage;
    updateDisplayedHeroStats();    
    if(heroCurrentHealth <= 0)
    {
        heroCurrentHealth = 0;
        heroIsDead = true;
        alert("you died. The game restarted");
        currentState = "GS";
        stateChanged();
    }

    if (heroCurrentHealth >= heroMaxHealth)
    {
        heroCurrentHealth = heroMaxHealth;
    }
    calculateHeroStats();
    updateDisplayedHeroStats();
}
function battlePhase()
{    
    if (enemyArray[0].isDead == false)
    {
        if(isHeroTurn == false && heroIsDead == false)
        {
            updateDisplayedEnemyStats();
            EnemyAI();
        }
    }
    else if(enemyArray[0].isDead == true && enemyArray[0].givenLoot == false)
    {
        enemyArray[0].givenLoot = true;
        lootGain(enemyArray[0].arrowLoot, "arrowLootID") //tells lootgain that we ae gaining arrows;
        lootGain(enemyArray[0].goldLoot, "goldLootID") // tells lootgain that we gain gold
        experienceGain(enemyArray[0].experienceLoot);  //could use this in "lootGain" but meh
        chatLogRef.innerHTML += `you gained loot!  ${enemyArray[0].goldLoot} gold, ${enemyArray[0].arrowLoot} arrows and ${enemyArray[0].experienceLoot} experience!`
        updateDisplayedHeroStats();
        resetDisplayedEnemyStats();
        currentState = "AP";
        stateChanged();
    }
}

/*function createEnemies(name, damage, hp, level, gold, arrow, ) // REPAIR || REMOVE
{
    let enemy = 
    {
        enemyName: name,
        baseDamage: damage,
        baseHp: hp,
        enemyLevel: level,
        goldLoot: gold,
        arrowLoot: arrow
    };
}*/

function stateChanged()
{
    switch (currentState) 
    {
        case "GS":
            calculateHeroStats(); //OK
            countResources(); //OK
            updateDisplayedHeroStats(); //OK
            swapButtonFunctionality();
            resetDisplayedEnemyStats();
            break;
        case "AP":
            swapButtonFunctionality();
            break;
        case "SUBP":
            createEnemy();
            break;
        case "BP":
            swapButtonFunctionality();
            isHeroTurn = true;
            battlePhase();
            console.log("BP")
            break;
        case "BRP":
            console.log("i is BRP.");
            break;
        case "TP":
            swapButtonFunctionality();
            break;
        case "SP":
            swapButtonFunctionality();
            break;
        case "IP":
            swapButtonFunctionality();
            break;
        case "BS":
            swapButtonFunctionality();
            break;
        case "SPBuy":
            swapButtonFunctionality();
            break;
        case "SPSell":
            swapButtonFunctionality();
            break;
        default: 
            console.log("i is something else");
            break;
    }
}
  //Had issue with functions fireing before HTML document was loaded. 
//onLoad waites for the HTML document to lead before "activating"

GameManager();
//body.onload = function(){loadMyStartFunctions()};
//onload="loadMyStartFunctions()">

//ADD SELLING FUNCTION AND "OPTIONS OR SOMETHING"
//ALLSO ADD TOWN