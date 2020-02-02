export const environment = {
  production: true,
  routes: {
    orders: '/orders',
    ordersEdit: '/orders/:id',
    orderAdd: '/orders/:id/add',
    vault: '/vault',
    vaultEdit: '/vault/:id',
    menu: '/menu',
    menuEdit: '/menu/:id',
    categories: '/categories',
    categoriesEdit: '/categories/:id',
    categoriesCreate: '/categories/create',
    report: '/report'
  },
  apiBaseUrl: 'https://localhost:44375/api'
};
