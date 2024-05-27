import { lazy } from 'react';
import {HomeOutlined} from "@ant-design/icons";

// Lazy imports
const Home = lazy(() => import('./Home'));
const Active = lazy(() => import('./Active'));

// Exporting components and lazy imports
const components = [
  {
    component: Home,
    key: 'home',
    name: 'home',
    label: 'Home',
    icon: <HomeOutlined />,
    // displayIndex: '0'
  },
  {
    component: Active,
    key: 'active',
    name: 'active',
    label: 'Active',
    icon: <HomeOutlined />,
    // displayIndex: '1'
    // children: [
    //   {
    //     component: Active,
    //     key: 'active/active1',
    //     name: 'active1',
    //     label: 'Active1',
    //     icon: <HomeOutlined/>,
    //     displayIndex: '0'
    //   },
    //   {
    //     component: Active,
    //     key: 'active/active2',
    //     name: 'active2',
    //     label: 'Active2',
    //     icon: <HomeOutlined/>,
    //     displayIndex: '1'
    //   }
    // ]
  }
];

export default components;
