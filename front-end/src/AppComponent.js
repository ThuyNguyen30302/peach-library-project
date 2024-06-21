import { lazy } from 'react';
import {HomeOutlined} from "@ant-design/icons"

// Lazy imports
const Home = lazy(() => import('./Home'));
const AuthorListView = lazy(() => import('./pages/author/view/AuthorListView'));
const PublisherListView = lazy(() => import('./pages/publisher/view/PublisherListView'));

// Exporting components and lazy imports
const components = [
  {
    component: Home,
    key: '/',
    name: 'home',
    label: 'Home',
    icon: <HomeOutlined />,
    displayIndex: '0'
  },
  {
    component: AuthorListView,
    key: '/author',
    name: 'author',
    label: 'Tác giả',
    icon: <span><i className="fa-solid fa-user-pen"></i></span>,
    displayIndex: '1'
  },
  {
    component: PublisherListView,
    key: '/publisher',
    name: 'publisher',
    label: 'Nhà phát hành',
    icon: <span><i className="fa-solid fa-swatchbook"></i></span>,
    displayIndex: '1'
  },
  {
    component: AuthorListView,
    key: '/book',
    name: 'book',
    label: 'Sách',
    icon: <span><i className="fa-solid fa-book"></i></span>,
    displayIndex: '1'
  },
  // {
    // component: Active,
    // key: '/active',
    // name: 'active',
    // label: 'Active',
    // icon: <HomeOutlined />,
    // displayIndex: '1',
    // children: [
    //   {
    //     component: Active,
    //     key: '/active/active1',
    //     name: 'active1',
    //     label: 'Active1',
    //     icon: <HomeOutlined/>,
    //     displayIndex: '0'
    //   },
    //   {
    //     component: Active,
    //     key: '/active/active2',
    //     name: 'active2',
    //     label: 'Active2',
    //     icon: <HomeOutlined/>,
    //     displayIndex: '1'
    //   }
    // ]
  // }
];

export default components;
