<p align="center"><img width="100" src="https://raw.githubusercontent.com/NeutroniumCore/neutronium-vue/master/template/src/assets/logo.png"></p>
<h1 align="center">Neutronium.SPA.Demo</h1>

## Chromeless

To render a chromeless window, with full behavior Neutronium.SPA.Demo 
1) uses Neutronium built-in chromeless behavior on the main window to set-up WPF behavior.

```XML
 <xmlns:WPF="clr-namespace:Neutronium.WPF;assembly=Neutronium.WPF" x:Class="Neutronium.SPA.Demo.MainWindow"
        xmlns:i="clr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity"
        BorderThickness="1"
        Title="MainWindow">
    <i:Interaction.Behaviors>
        <WPF:Chromeless />
    </i:Interaction.Behaviors>
```
2) uses [`-webkit-app-region` CSS property](https://developer.chrome.com/apps/app_window) to define draggable zone on the HTML window:

```CSS
#top-menu > div{
  -webkit-app-region: drag;
}

#top-menu > div > button{
  -webkit-app-region: no-drag;
}
```

3) uses a dedicated Vue.js component: [topMenu.vue](../Neutronium.SPA.Demo/View/Main/src/components/topMenu.vue) bound to a WindowViewModel to allow to minimize/maximize/close the corresponding window.

```HTML
<v-toolbar id="top-menu"  app >

    <icon-button :command="window.Minimize" icon="remove">
    </icon-button>

    <icon-button :command="window.Normalize" :icon="middleIcon">
    </icon-button>

    <icon-button :command="window.Close" icon="close">
    </icon-button>

</v-toolbar>
```

Back to [README](../README.md)
