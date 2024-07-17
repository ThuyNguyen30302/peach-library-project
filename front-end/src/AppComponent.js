import {lazy} from 'react';
import {HomeOutlined, SettingOutlined} from "@ant-design/icons"
import {Tooltip} from "antd";
import LabelTooltipForMenuItem from "./layouts/LabelTooltipForMenuItem";

// Lazy imports
const Home = lazy(() => import('./Home'));
const AuthorListView = lazy(() => import('./pages/author/view/AuthorListView'));
const PublisherListView = lazy(() => import('./pages/publisher/view/PublisherListView'));
const MemberListView = lazy(() => import('./pages/member/view/MemberListView'));
const MetaCataloListView = lazy(() => import('./pages/metacatalo/veiw/MetaCataloListView'));
const CataloListView = lazy(() => import('./pages/metacatalo/veiw/CataloListView'));
const BookListView = lazy(() => import('./pages/book/view/BookListView'));
const BorrowListView = lazy(() => import('./pages/borrow/view/BorrowListView'));
const BorrowBookListView = lazy(() => import('./pages/borrow/view/BorrowBookListView'));
const ImportBookListView = lazy(() => import('./pages/import-book/view/ImportBookListView'));

// Exporting components and lazy imports
export const routeComponents = [
  // {
  //   component: Home,
  //   key: '/',
  //   name: 'home',
  //   label: <LabelTooltipForMenuItem label={'Home'} />,
  //   icon: <HomeOutlined/>,
  //   displayIndex: '0'
  // },
  {
    component: AuthorListView,
    key: '/author',
    name: 'author',
    label: <LabelTooltipForMenuItem label={'Tác giả'} />,
    icon: <span><i className="fa-solid fa-user-pen"></i></span>,
    displayIndex: '1'
  },
  {
    component: PublisherListView,
    key: '/publisher',
    name: 'publisher',
    label: <LabelTooltipForMenuItem label={'Nhà phát hành'} />,
    icon: <span><i className="fa-solid fa-swatchbook"></i></span>,
    displayIndex: '2'
  },
  {
    component: MemberListView,
    key: '/member',
    name: 'member',
    label: <LabelTooltipForMenuItem label={'Thành viên'} />,
    icon: <span><i className="fa-solid fa-user"></i></span>,
    displayIndex: '3'
  },
  {
    key: '/manage-book',
    name: 'manage-book',
    label: <LabelTooltipForMenuItem label={'Quản lý sách'} />,
    icon: <span><i className="fa-solid fa-sliders"></i></span>,
    displayIndex: '4',
    children: [
      {
        component: BookListView,
        key: '/manage-book/book',
        name: 'book',
        label: <LabelTooltipForMenuItem label={'Kho sách'} />,
        icon: <span><i className="fa-solid fa-book"></i></span>,
        displayIndex: '0',
      },
      {
        component: ImportBookListView,
        key: '/manage-book/import-book',
        name: 'import-book',
        label: <LabelTooltipForMenuItem label={'Nhập sách'} />,
        icon: <span><i className="fa-solid fa-book-open"></i></span>,
        displayIndex: '1',
      },
      // {
      //   component: BookListView,
      //   key: '/manage-book/warehouse-book',
      //   name: 'warehouse-book',
      //   label: 'Kho sách',
      //   icon: <span><i className="fa-solid fa-book-bookmark"></i></span>,
      //   displayIndex: '2',
      // },
    ]
  },
  {
    key: '/manage-borrow',
    name: 'manage-borrow',
    title: 'Quản lý mượn trả',
    label: <LabelTooltipForMenuItem label={'Quản lý mượn trả'} />,
    icon: <span><i className="fa-solid fa-sliders"></i></span>,
    displayIndex: '5',
    children: [
      {
        component: BorrowListView,
        title: 'Danh sách người mượn',
        key: '/manage-borrow/borrow',
        name: 'borrow',
        label: <LabelTooltipForMenuItem label={'Danh sách người mượn'} />,
        icon: <span><i className="fa-solid fa-book"></i></span>,
        displayIndex: '0',
      },
      {
        component: BorrowBookListView,
        title: 'Danh sách sách mượn',
        key: '/manage-borrow/borrow-book',
        name: 'borrow-book',
        label: <LabelTooltipForMenuItem label={'Danh sách sách mượn'} />,
        icon: <span><i className="fa-solid fa-book"></i></span>,
        displayIndex: '1',
      },
      // {
      //   component: BorrowBookListView,
      //   title: 'Danh sách quá hạn',
      //   key: '/manage-borrow/overdue',
      //   name: 'overdue',
      //   label: <LabelTooltipForMenuItem label={'Danh sách quá hạn'} />,
      //   icon: <span><i className="fa-solid fa-book"></i></span>,
      //   displayIndex: '2',
      // },
    ]
  },
  {
    key: '/config',
    name: 'config',
    label: <LabelTooltipForMenuItem label={'Cấu hình'} />,
    icon: <span><i className="fa-solid fa-gear"></i></span>,
    displayIndex: '4',
    children: [
      {
        component: MetaCataloListView,
        key: '/config/metacatalo',
        name: 'metacatalo',
        label: <LabelTooltipForMenuItem label={'Danh mục'} />,
        icon: <span><i className="fa-solid fa-bars"></i></span>,
        displayIndex: '0'
      },
      // {
      //   component: Active,
      //   key: '/active/active2',
      //   name: 'active2',
      //   label: 'Active2',
      //   icon: <HomeOutlined/>,
      //   displayIndex: '1'
      // }
    ]
  }
];

export const noRouteComponents = [
  {
    component: CataloListView,
    key: '/config/metacatalo/catalo/:id',
    name: 'catalo',
    label: 'Tiểu mục',
    displayIndex: '0'
  },
]