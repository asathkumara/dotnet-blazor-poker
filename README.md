![image](https://user-images.githubusercontent.com/28933557/175179746-b8adb190-f6a8-480d-9dae-fd6fc9793223.png)

<table >
    <tr>
        <th>Roles</th>
        <th>Deliverables</th>
        <th>Project Specifications</th>
    </tr>
    <tr>
        <td style="">
            <p >I assumed the following roles when designing this app:</p>
            <ul>
                <li>Full-Stack Developer</li>
                <li>User Experience (UX) Designer</li>
                <li>User Interface (UI) Designer</li>
                <li>Interaction (IxD) Designer</li>
                <li>QA Tester</li>
            </ul>
        </td>
        <td style="">
           <p>Full-Stack Development: Progressive web application (PWA) built using .NET and Blazor Webassembly (WASM)</p>
            <p>Interaction Design: High-fidelity prototypes for key tasks on desktop and mobile.</p>
            <p>UX/UI Design:</p>
            <ul>
                <li>UI Kit</li>
                <li>High-fidelity mockups and prototypes</li>
            </ul>
            <p>QA Testing: </p>
            <ul>
                <li>Windows Narrator testing session</li>
            </ul>
        </td>
        <td style="">
           <p>Duration: 2 weeks to port to Blazor Webassembly and refactor initial console application which was 2 years old</p>
           <p>This project is still undergoing development</p>
           <p>Tools</p>
           <ul>
                <li>Figma</li>
                <li>Photoshop</li>
            </ul>
        </td>
    </tr>    
</table>

> The game is available at https://dotnet-blazor-poker.vercel.app/


## Table of Contents

1. [Overview](#overview)
2. [Gameplay](#gameplay)
3. [Design](#design)</br>
-- [UI Kit](#ui-kit)</br>
-- [Prototypes](#prototype)
4. [Accessibility](#accessibility)</br>
-- [Windows Narrator testing session](#narrator-session)
5. [License](#license)


## Overview

This poker game is a simplified version of the Five-card draw (also known as the Cantrell draw) poker variant. While it is not as popular as seven-card stud or Texas hold'em, it is considered to be the best variant for new players.

By simplifying the variant further and limiting the game to one player, this app intends to teach new players about the various poker hand rankings (such as Royal Flush, Straight Flush, etc.) as they go through the various rounds. 

<a style="font-size: 20px" href="https://dotnet-blazor-poker.vercel.app" target="_blank" title="Ctrl click to open in new window. Markdown doesn't support this yet.">> Open game</a>

## Gameplay

The game begins with the player being dealt five cards, all face down, and a balance of 3000 credits. To ensure randomness, to an extent, the deck is shuffled using the [Fisher-Yates algorithm](https://en.wikipedia.org/wiki/Fisher%E2%80%93Yates_shuffle) and the top card is burned before dealing the initial hand.

Once the player picks up and reveals their cards, the betting round begins. Players can bet in increments of 1, 5, 25 and 100 as long as they have the credits to do so. Once the bets are placed the dealer subtracts the credits from the player and adds it to the pot, initiating the draw round.

A common "house rule" in some places is that a player may not replace more than three cards. This rule is used in this game and is beneficial in helping slow the depletion of the deck. If the deck is ever depleted mid-game, the dealer will re-shuffle the deck and burn the top card. 

Once the player confirms their selection of cards to redraw or keeps their hand, the showdown round begins revealing their hand's poker ranking. Credits awarded will be based on the bets placed during the betting round and the rarity of the poker hand:

<table>
    <tr>
        <th>Ranking</th>
        <th>Factor</th>
    </tr>
    <tr>
        <td>
            Royal Flush
        </td>
        <td>
            0.9
        </td>
    </tr>
    <tr>
        <td>
            Straight Flush
        </td>
        <td>
            0.8
        </td>
    </tr>
    <tr>
        <td>
            4 Of A Kind
        </td>
        <td>
            0.7
        </td>
    </tr>
    <tr>
        <td>
            Full House
        </td>
        <td>
            0.6
        </td>
    </tr>
    <tr>
        <td>
            Straight
        </td>
        <td>
            0.5
        </td>
    </tr>
    <tr>
        <td>
           3 Of A Kind
        </td>
        <td>
            0.4
        </td>
    </tr>
    <tr>
        <td>
            2 Of A Kind
        </td>
        <td>
            0.3
        </td>
    </tr>
    <tr>
        <td>
            Two Pair
        </td>
        <td>
            0.2
        </td>
    </tr>
</table>

To put this into perspective: if you bet 150 credits on the betting round and received a Royal Flush on the showdown, you will be awarded 285 credits (150 + (150 * 0.9)). If your hand is a One Pair or a High Card, you will lose your initial bet. 

Once the approriate number of credits are awarded, the player can request to be dealt another hand starting the gameplay loop. The game will continue until the player exits or exhausts their credits.

Will you be crushed by the rng gods or prevail as the next blazor poker champ. Only time will tell and as always, gamble responsibly. 

> Note: The game currently does not explain the poker hands and does not include existing audio assets. In future updates, that functionality will be worked in via new menus.


## Design

[![Image from Gyazo](https://i.gyazo.com/6f581db8ccff804ac1302fa92cf1f754.gif)](https://gyazo.com/6f581db8ccff804ac1302fa92cf1f754)

The focal point of any card game should be the cards and that heavily influenced my design choices. I also wanted a retro and vintage feel to the game (almost reminiscient of a NES or Namco Arcade game) so I started by developing a **UI Kit** to clarify the visual design. Details such as button states and typography were important to clearly define. 

<a id="ui-kit" href="https://www.figma.com/file/4pVWzaeRrxvkILZWizTja9/Dotnet-Blazor-Poker-UI-Kit-(V2)?node-id=0%3A1" target="_blank" title="Ctrl click to open in new window. Markdown doesn't support this yet.">> Open Figma UI Kit</a>

The background image evokes the feeling of the game being played on a poker table felt, establishing the primary color palette and allowing the cards to be the focal point.  The global use of the [Press Start 2P](https://www.dafont.com/press-start-2p.font) font captures that retro game feeling.

 To increase interactivity, each card and poker chip has a tilt effect when hovered, shifting their perspective from 2D into 3D. Buttons have a "pressed" effect when held down as well.

**High fidelity prototypes** allowed me to test the key mechanics of the game and interactions with the UI. 

<a id="prototype" href="https://www.figma.com/proto/3SvRktfouIOBqVEeurfqV3/Dotnet-Blazor-Poker---Prototype-V2?node-id=207%3A680&scaling=scale-down&page-id=206%3A2&starting-point-node-id=207%3A680" target="_blank" title="Ctrl click to open in new window. Markdown doesn't support this yet.">> Open Figma desktop high-fidelity prototype</a>

<a href="https://www.figma.com/proto/3SvRktfouIOBqVEeurfqV3/Dotnet-Blazor-Poker---Prototype-V2?node-id=207%3A697&scaling=scale-down&page-id=207%3A696&starting-point-node-id=207%3A697" target="_blank" title="Ctrl click to open in new window. Markdown doesn't support this yet.">> Open Figma mobile high-fidelity prototype</a>

## Accessibility

<img src="https://user-images.githubusercontent.com/28933557/176834460-4e8ec7fe-c0c9-44ee-abb8-d3e9d2d8e8c0.png" width="900" height="350"/>

Many users with disabilities are unable to use a mouse or other pointing device and must rely on keyboards for a majority of their browsing. For this reason, I wanted to ensure that my game was practical for keyboard use -- to a certain extent.

In addition to periodic testing on supported devices, I did less frequent but thorough testing from an accessibility perspective using the following tools:

<ul>
    <li>Windows Narrator</li>
    <li>VoiceOver on iOS</li>
    <li>Color Contrast Analyzer Extension</li>
    <li>High Contrast Emulation on Browsers</li>
</ul>

Creating accessibile formats for some game mechanics or content may be unfeasible or impractical. Please expect some portions of this website to not be in compliance with the Web Content Accessibility Guidelines (WCAG) and some portions to only meet the minimum required compliance standards.

The following recording of a **Windows Narrator testing session** demonstrates custom focus styles, custom focus behavior and various ARIA elements in action:

<a id="narrator-session" href="https://www.youtube.com/watch?v=pj3WPCtROzc" target="_blank" title="Ctrl click to open in new window. Markdown doesn't support this yet.">> Open Windows Narrator testing session</a>




## License

This project is licensed under [MIT](https://github.com/asathkumara/dotnet-blazor-poker/blob/master/LICENSE). Feel free to re-use any libraries or code for **non-commercial use** but do your due diligence with attributing credit.

The images for the playing cards were adapted from [Improve Magic](https://www.improvemagic.com/all-playing-cards-names-with-pictures/) and the project makes use of other royalty-free assets modified under fair use.
