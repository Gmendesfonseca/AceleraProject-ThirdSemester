import { Stack, ThemeProvider, createTheme, Box } from '@mui/material';
import { Navbar } from '../../components/HomeComponents/NavBar/Navbar';
import { HeadCell, InTable } from '../../components/Table/Table';
import faker from 'faker';
import { More } from '../../components/More/More';
import { FriendsListType } from '../../services/friends';

const headCells: readonly HeadCell<FriendsListType>[] = [
  { id: 'name', numeric: false, disablePadding: false, label: 'Name' },
  { id: 'email', numeric: false, disablePadding: false, label: 'Email' },
  { id: 'online', numeric: false, disablePadding: false, label: 'Status' },
  { id: 'options', numeric: false, disablePadding: false, label: 'Opções' },
];

const rows: FriendsListType[] = Array.from({ length: 50 }, (_, index) => ({
  id: index + 1,
  name: faker.company.companyName(),
  email: faker.internet.email(),
  online: faker.random.arrayElement(['Online', 'Offline']),
  options: <More type="Amizade" id={index + 1} idMore={index + 1} />,
}));

export default function ListFriends() {
  const darkTheme = createTheme({
    palette: {
      mode: 'dark',
    },
  });

  return (
    <ThemeProvider theme={darkTheme}>
      <Box bgcolor={'background.default'} color={'text.primary'}>
        <Navbar />
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