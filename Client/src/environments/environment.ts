// This file can be replaced during build by using the `fileReplacements` array.
// `ng build --prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

export const environment = {
  production: false,
  routes: {
    orders: 'orders',
    ordersEdit: 'orders/:id',
    orderAdd: 'orders/:id/add',
    vault: 'vault',
    vaultEdit: 'vault/:id',
    menu: 'menu',
    menuEdit: 'menu/:id',
    categories: 'categories',
    categoriesEdit: 'categoryEdit',
    categoriesCreate: 'categories/create',
    report: 'report'
  },
  apiBaseUrl: 'https://localhost:44375/api'
};

/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/dist/zone-error';  // Included with Angular CLI.
