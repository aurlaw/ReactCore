import React, {Suspense} from 'react';
import ReactDOM from 'react-dom';
// import App from './App';
// import CommentBox from './apps/CommentBox';
// import Privacy from './apps/Privacy';
import ProgressBar from './Progress';
const CommentBox = React.lazy(() => import('./apps/CommentBox'));
const Privacy = React.lazy(() => import('./apps/Privacy'));
const WebWorker = React.lazy(() => import('./apps/WebWorker'));
const Animation = React.lazy(() => import('./apps/Animation'));
const Generator = React.lazy(() => import('./apps/Generator')); 

const APPS = {
    CommentBox,
    Privacy,
    WebWorker,
    Animation,
    Generator
    // App
};

function renderAppInElement(el) {
    var id = el.id;
    var idArr = id.split('_');
    if(idArr.length > 1) {
        id = idArr[idArr.length-1];
    }

    var App = APPS[id];
    if (!App) return;
  
    // get props from elements data attribute, like the post_id
    const props = Object.assign({}, el.dataset);
  


    ReactDOM.render(
        <Suspense fallback={<ProgressBar loadingValue="Loading..." />}>
            <App {...props} />
        </Suspense>
        , el);
}
// eslint-disable-next-line no-undef
document.querySelectorAll('.__react-root').forEach(renderAppInElement);




/*
const OtherComponent = React.lazy(() => import('./OtherComponent'));
const AnotherComponent = React.lazy(() => import('./AnotherComponent'));

<Suspense fallback={<div>Loading...</div>}>
        <section>
          <OtherComponent />
          <AnotherComponent />
        </section>
      </Suspense>

*/
