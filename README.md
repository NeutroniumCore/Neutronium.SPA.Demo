<p align="center"><img width="100" src="https://raw.githubusercontent.com/NeutroniumCore/neutronium-vue/master/template/src/assets/logo.png"></p>
<h1 align="center">Neutronium.SPA.Demo</h1>


[![MIT License](https://img.shields.io/github/license/NeutroniumCore/Neutronium.SPA.Demo.svg)](https://github.com/NeutroniumCore/Neutronium.SPA.Demo/blob/master/LICENSE)

## Description

This project is a demo application illustrating how it is possible to structure a medium to large project using [Neutronium](https://github.com/NeutroniumCore/Neutronium) and [Vue.js](https://vuejs.org) binding.

It can be used as a starter for building a new solution, or as a reference Neutronium implementation regarding:
* routing
* internalization
* chromeless window
* dependency injection

It is built on the top of [Vuetifyjs](https://vuetifyjs.com) material component framework.


## Routing

Neutronium.SPA.Demo illustrates how to integrate with [vue-router](https://router.vuejs.org/en/).
See more details [here](./Documentation/Routing.md)

## Internalization

Integration with [vue-i18n](https://kazupon.github.io/vue-i18n/en/) is provided.


Resource.resx is used on the C# side and transformed by [message.tt](./Neutronium.SPA.Demo/View/Main/src/message.tt) into a `.json` file that is used by `vue-i18n` as resource.<br>

For example, to reference `About1` key defined as below:
<img src="./Screenshots/resource.png"><br>

Just do:

```HTML
<v-list-tile-title v-text="$t('Resource.About1')"></v-list-tile-title>
```

## Chromeless Window

To render a chromeless window, with full behaviour Neutronium.SPA.Demo uses a combination of Neutronium built in chromeless behavior on the main window:

```XML
 <xmlns:WPF="clr-namespace:Neutronium.WPF;assembly=Neutronium.WPF" x:Class="Neutronium.SPA.Demo.MainWindow"
        xmlns:i="clr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity"
        BorderThickness="1"
        Title="MainWindow">
    <i:Interaction.Behaviors>
        <WPF:Chromeless />
    </i:Interaction.Behaviors>
```
Usage of [`-webkit-app-region` CSS property](https://developer.chrome.com/apps/app_window):

```CSS
#top-menu > div{
  -webkit-app-region: drag;
}

#top-menu > div > button{
  -webkit-app-region: no-drag;
}
```

## Screenshots

<img src="./Screenshots/Screenshot1.png"><br>

<img src="./Screenshots/Screenshot2.png"><br>

<img src="./Screenshots/Screenshot3.png"><br>

<img src="./Screenshots/Screenshot5.png"><br>


## Built with

<p style="margin-left:100px;" align="">
<a href="https://vuetifyjs.com">
<img src="./Neutronium.SPA.Demo/View/Main/src/assets/v.png" height="50px">
</a>
<a href="https://github.com/NeutroniumCore/Neutronium">
<img src="https://raw.githubusercontent.com/NeutroniumCore/neutronium-vue/master/template/src/assets/logo.png" height="50px">
</a>
<a href="https://vuejs.org">
<img src="https://vuejs.org/images/logo.png" height="50px">
</a>
</p>




