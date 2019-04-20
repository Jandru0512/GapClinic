import React, { Suspense } from 'react';
import ReactDOM from 'react-dom';
import { Provider } from 'react-redux';
import { BrowserRouter as Router } from 'react-router-dom';
import { LocaleProvider, Spin } from 'antd';
import { getPersistor } from '@rematch/persist';
import { PersistGate } from 'redux-persist/integration/react';
import Layout from './pages/Layout';
import { store } from './configurations';
import es_ES from 'antd/lib/locale-provider/es_ES';
import * as registerServiceWorker from './registerServiceWorker';
import './styles/index.less';

const persistor = getPersistor();

const AppSuspense = () => (
  <Suspense fallback={<Spin size="large" className="custom-layout-spin" />}>
    <App />
  </Suspense>
);

const App = () => {
  return (
    <LocaleProvider locale={es_ES}>
      <Provider store={store}>
        <PersistGate persistor={persistor}>
          <Router>
            <Layout />
          </Router>
        </PersistGate>
      </Provider>
    </LocaleProvider>
  );
};

ReactDOM.render(<AppSuspense />, document.getElementById('root'));
registerServiceWorker.register();
