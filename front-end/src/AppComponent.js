import { lazy } from "react";
import { HomeOutlined, SettingOutlined } from "@ant-design/icons";

// Lazy imports
const Home = lazy(() => import("./pages/home/Home"));
const AuthorListView = lazy(() => import("./pages/author/view/AuthorListView"));
const PublisherListView = lazy(() =>
  import("./pages/publisher/view/PublisherListView")
);
const MemberListView = lazy(() => import("./pages/member/view/MemberListView"));
const MetaCataloListView = lazy(() =>
  import("./pages/metacatalo/veiw/MetaCataloListView")
);
const CataloListView = lazy(() =>
  import("./pages/metacatalo/veiw/CataloListView")
);
const BookListView = lazy(() => import("./pages/book/view/BookListView"));
const ImportBookListView = lazy(() =>
  import("./pages/import-book/view/ImportBookListView")
);

// Exporting components and lazy imports
export const routeComponents = [
  {
    component: Home,
    key: "/",
    name: "home",
    // label: <LabelTooltipForMenuItem label={"Trang chủ"} />,
    icon: <HomeOutlined />,
    displayIndex: "0",
  },
  {
    component: AuthorListView,
    key: "/author",
    name: "author",
    label: "Tác giả",
    icon: (
      <span>
        <i className="fa-solid fa-user-pen"></i>
      </span>
    ),
    displayIndex: "1",
  },
  {
    component: PublisherListView,
    key: "/publisher",
    name: "publisher",
    label: "Nhà phát hành",
    icon: (
      <span>
        <i className="fa-solid fa-swatchbook"></i>
      </span>
    ),
    displayIndex: "2",
  },
  {
    component: MemberListView,
    key: "/member",
    name: "member",
    label: "Thành viên",
    icon: (
      <span>
        <i className="fa-solid fa-user"></i>
      </span>
    ),
    displayIndex: "3",
  },
  {
    key: "/manage-book",
    name: "manage-book",
    label: "Quản lý sách",
    icon: (
      <span>
        <i className="fa-solid fa-sliders"></i>
      </span>
    ),
    displayIndex: "4",
    children: [
      {
        component: BookListView,
        key: "/manage-book/book",
        name: "book",
        label: "Kho sách",
        icon: (
          <span>
            <i className="fa-solid fa-book"></i>
          </span>
        ),
        displayIndex: "0",
      },
      {
        component: ImportBookListView,
        key: "/manage-book/import-book",
        name: "import-book",
        label: "Nhập sách",
        icon: (
          <span>
            <i className="fa-solid fa-book-open"></i>
          </span>
        ),
        displayIndex: "1",
      },
      // {
      //   component: BookListView,
      //   key: '/manage-book/warehouse-book',
      //   name: 'warehouse-book',
      //   label: 'Kho sách',
      //   icon: <span><i className="fa-solid fa-book-bookmark"></i></span>,
      //   displayIndex: '2',
      // },
    ],
  },
  {
    key: "/config",
    name: "config",
    label: "Cấu hình",
    icon: (
      <span>
        <i className="fa-solid fa-gear"></i>
      </span>
    ),
    displayIndex: "4",
    children: [
      {
        component: MetaCataloListView,
        key: "/config/metacatalo",
        name: "metacatalo",
        label: "Danh mục",
        icon: (
          <span>
            <i className="fa-solid fa-bars"></i>
          </span>
        ),
        displayIndex: "0",
      },
      // {
      //   component: Active,
      //   key: '/active/active2',
      //   name: 'active2',
      //   label: 'Active2',
      //   icon: <HomeOutlined/>,
      //   displayIndex: '1'
      // }
    ],
  },
];

export const noRouteComponents = [
  {
    component: CataloListView,
    key: "/config/metacatalo/catalo/:id",
    name: "catalo",
    label: "Tiểu mục",
    displayIndex: "0",
  },
];
