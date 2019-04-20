import { init } from '@rematch/core';
import createRematchPersist from '@rematch/persist';
import createLoadingPlugin from '@rematch/loading';
import * as models from '../models';

const persistPlugin = createRematchPersist({
  whitelist: ['authenticated', 'authentication'],
  keyPrefix: '--persist-key-',
  throttle: 500,
  version: 1,
});

const loadingPlugin = createLoadingPlugin({});

const store = init({
  models,
  plugins: [persistPlugin, loadingPlugin],
});

export default store;
