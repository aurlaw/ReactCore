# React Component Core

<!-- [![Build status](https://gatesman.visualstudio.com/Kentico-Cloud-Samples/_apis/build/status/Digital%20Core)](https://gatesman.visualstudio.com/Kentico-Cloud-Samples/_build/latest?definitionId=11)

[![Deployment status](https://gatesman.vsrm.visualstudio.com/_apis/public/Release/badge/1d4fed9c-e9f8-438e-98fa-b43580c59c41/2/2)](https://gatesman.vsrm.visualstudio.com/_apis/public/Release/badge/1d4fed9c-e9f8-438e-98fa-b43580c59c41/2/2) -->

<!-- Hosted: https://digital-core.azurewebsites.net/ -->


.NET Core 3.1 with React components. Uses Parcel for build environment of React and Sass.
This is not a SPA, it is a .NET Core MVC app utlizing individual React components - see ```ReactCore/ClientComponents/src/index.js``` for set up of components. The app also communicates with a gRPC service to showcase gRPC integration within .NET Core.

Each component is mounted within an HTML element using the class "__react-root" and an id representing the name of the component to mount.

```HTML
    <div id="CommentBox" 
        data-post_id="10" class="__react-root">
   </div>

```

### Requires
* .NET Core 3.1
* Node 10+
* Parcel

### gRPC Server

```
cd GrpcService
dotnet restore
dotnet run
```

## React Core 
### Installing Parcel
Yarn:

```yarn global add parcel-bundler```

npm:

```npm install -g parcel-bundler```


### Running with Watch:

```cd ReactCore```

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

Point browser to http://localhost:8020

### Publishing
Yarn:

```
yarn run build
```

npm:

```
npm run build
```


### TODO

Set up on Azure as two separate apps (MVC and gRPC server)

Dockerize

https://medium.com/greedygame-engineering/so-you-want-to-dockerize-your-react-app-64fbbb74c217

