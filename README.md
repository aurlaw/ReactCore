# React Component Core

<!-- [![Build status](https://gatesman.visualstudio.com/Kentico-Cloud-Samples/_apis/build/status/Digital%20Core)](https://gatesman.visualstudio.com/Kentico-Cloud-Samples/_build/latest?definitionId=11)

[![Deployment status](https://gatesman.vsrm.visualstudio.com/_apis/public/Release/badge/1d4fed9c-e9f8-438e-98fa-b43580c59c41/2/2)](https://gatesman.vsrm.visualstudio.com/_apis/public/Release/badge/1d4fed9c-e9f8-438e-98fa-b43580c59c41/2/2) -->

Hosted: https://digital-core.azurewebsites.net/


.NET Core 2.2 with React components. Uses Parcel for build environment of React and Sass.
This is not a SPA, it is a .NET Core MVC with React components - see ```digital-core/ClientComponents/src/index.js``` for set up of components.

Each component is mounted within an HTML element using the class "__react-root" and an id representing the name of the component to mount.

```HTML
    <div id="CommentBox" 
        data-post_id="10" class="__react-root">
   </div>

```

### Requires
* Dotnet Core 2.2
* Node 10+
* Parcel

### Installing Parcel
Yarn:

```yarn global add parcel-bundler```

npm:

```npm install -g parcel-bundler```


### Running with Watch:

```cd src```

Yarn:

```
yarn install
yarn start
```

npm:

```
npm install
npm start
```

### Publishing
Yarn:

```
yarn run build
```

npm:

```
npm run build
```



## React SPA
```kcloud-sample-app-react/README.md```

```
cd kcloud-sample-app-react
npm install
npm start
```

Use Project ID manually - ```fee035b7-c253-00ba-ed5c-d33054bd56d8```

## ASP.NET MVC
```kcloud-sample-app-net/README.md```

Launch ```kcloud-sample-app-net/DancingGoat.sln``` in Visual Studio 2017




### Dockerize

TODO

https://medium.com/greedygame-engineering/so-you-want-to-dockerize-your-react-app-64fbbb74c217

