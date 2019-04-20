import React, { useState, Suspense } from 'react';
import PropTypes from 'prop-types';
import { Route, Switch, withRouter, Redirect } from 'react-router-dom';
import { Layout, Drawer, Spin } from 'antd';
import { GUEST, LOGGED } from '../configurations/constants';
import routes from '../configurations/routes';
import { MenuPrimary, Logo, Header } from '../components/Layout';
import { useAuthenticated } from '../components/Authentication/Hooks';
import { Login } from './';
import PageNotFound404 from './404';

const { Footer, Content, Sider } = Layout;

const Routes = ({ authenticated }) => {
  return (
    <Suspense fallback={<Spin size="large" className="custom-layout-spin" />}>
      <Switch>
        {routes.map(route => (
          <Route
            key={route.index}
            exact={route.exact ? route.exact : false}
            path={route.path}
            render={props =>
              route.when === undefined ||
              route.when === null ||
              (authenticated === false && route.when === GUEST) ||
              (authenticated === true && route.when === LOGGED) ? (
                React.createElement(route.component, props, null)
              ) : (
                <Redirect to="/login" />
              )
            }
          />
        ))}
        <Route component={PageNotFound404} />
      </Switch>
    </Suspense>
  );
};

const Document = props => {
  const {
    location: { pathname },
  } = props;

  const { authenticated } = useAuthenticated();
  const [visible, setVisible] = useState(false);
  const [collapsed, setCollapsed] = useState(false);

  const showDrawer = () => setVisible(true);
  const onClose = () => setVisible(false);
  const toggleCollapse = () => setCollapsed(!collapsed);

  return authenticated ? (
    <Layout className="custom-layout">
      <Sider
        width={250}
        breakpoint="md"
        collapsedWidth="0"
        collapsed={collapsed}
        onCollapse={toggleCollapse}
        className="custom-layout-sider">
        <Logo />
        <strong className="custom-menu-title">Dashboard</strong>
        <MenuPrimary pathname={pathname} />
      </Sider>
      <Drawer
        title={<Logo />}
        placement="left"
        onClose={onClose}
        visible={visible}
        bodyStyle={{ padding: 0, margin: 0 }}>
        <MenuPrimary pathname={pathname} onClick={onClose} />
      </Drawer>
      <Layout style={{ marginLeft: collapsed ? 0 : 250 }}>
        <Header
          pathname={pathname}
          collapsed={collapsed}
          showDrawer={showDrawer}
          drawerVisible={visible}
        />
        <Content className="custom-layout-content">
          <Routes authenticated={authenticated} />
        </Content>
        {/* <Footer>Footer</Footer> */}
      </Layout>
    </Layout>
  ) : (
    <Login />
  );
};

Document.propTypes = {
  location: PropTypes.object,
};

export default withRouter(Document);
