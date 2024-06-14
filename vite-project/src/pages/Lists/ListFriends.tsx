import { Stack, ThemeProvider, Box } from '@mui/material';
import { NavBar } from '../../components/HomeComponents/NavBar/Navbar';
import { HeadCell, InTable } from '../../components/Table/Table';
import faker from 'faker';
import { More } from '../../components/More/More';
import { FriendsListType } from '../../services/friends';
import { useNavigate } from 'react-router-dom';
import { darkTheme } from '../../Themes';
import { useSession } from '../../context/SessionContext';

const headCells: readonly HeadCell<FriendsListType>[] = [
  { id: 'name', numeric: false, disablePadding: false, label: 'Name' },
  { id: 'email', numeric: false, disablePadding: false, label: 'Email' },
  { id: 'online', numeric: false, disablePadding: false, label: 'Status' },
  { id: 'options', numeric: false, disablePadding: false, label: 'Opções' },
];

export default function ListFriends() {
  const navigate = useNavigate();
  const { user } = useSession();

  const rows: FriendsListType[] = user
    ? user.friends.map((friend) => ({
        ...friend,
        id: friend.id,
        email: friend.email,
        options: <More type="Amizade" id={1} idMore={1} />,
      }))
    : Array.from({ length: 50 }, (_, index) => ({
        id: index + 1,
        name: faker.company.companyName(),
        email: faker.internet.email(),
        online: faker.random.arrayElement(['Online', 'Offline']),
        options: <More type="Amizade" id={index + 1} idMore={index + 1} />,
      }));

  const btnBackHome = (
    <button title="back" className="backHome" onClick={() => navigate('/home')}>
      <svg
        xmlns="http://www.w3.org/2000/svg"
        viewBox="0 0 20 20"
        fill="currentColor"
        className="size-5"
      >
        <path
          fillRule="evenodd"
          d="M11.78 5.22a.75.75 0 0 1 0 1.06L8.06 10l3.72 3.72a.75.75 0 1 1-1.06 1.06l-4.25-4.25a.75.75 0 0 1 0-1.06l4.25-4.25a.75.75 0 0 1 1.06 0Z"
          clipRule="evenodd"
        />
      </svg>
    </button>
  );

  return (
    <ThemeProvider theme={darkTheme}>
      <Box bgcolor={'background.default'} color={'text.primary'}>
        <NavBar navAct={btnBackHome} />
        <Stack direction="row" spacing={2} justifyContent="center">
          {/* <SidebarMenu mode={mode} setMode={setMode} /> */}
          <InTable<FriendsListType>
            title="Conexões"
            name={null}
            rowsItems={rows}
            headCells={headCells}
          />
        </Stack>
      </Box>
    </ThemeProvider>
  );
}