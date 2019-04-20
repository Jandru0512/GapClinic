import React from 'react';
import { Icon, Layout, Row, Col } from 'antd';
import PropTypes from 'prop-types';
import MenuHeader from './MenuHeader';

const Header = ({ pathname, collapsed, showDrawer, drawerVisible }) => (
  <Layout.Header className="custom-header">
    <Row type="flex" align="middle" justify="space-between">
      <Col>
        {collapsed && (
          <Icon
            type={drawerVisible ? 'menu-fold' : 'menu-unfold'}
            onClick={showDrawer}
            className="custom-header-toggle-icon"
          />
        )}
      </Col>
      <Col span={18} order={2} className="custom-align-right">
        <Row type="flex" align="middle" justify="end">
          <MenuHeader collapsed={collapsed} pathname={pathname} />
        </Row>
      </Col>
    </Row>
  </Layout.Header>
);

Header.propTypes = {
  pathname: PropTypes.string,
  collapsed: PropTypes.bool,
  drawerVisible: PropTypes.bool,
  showDrawer: PropTypes.func,
};

Header.defaultProps = {
  collapsed: false,
  drawerVisible: false,
};

export default Header;
