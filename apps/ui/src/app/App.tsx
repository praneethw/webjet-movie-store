import styled from 'styled-components';

import { Route, Routes } from 'react-router-dom';
import { Movies, Header } from './components';
import { MovieDetail } from './components/MovieDetail';

const StyledApp = styled.div`
  // Your style here
`;

export function App() {
  return (
    <StyledApp>
      <Header />
      <Routes>
        <Route path="/" element={<Movies />} />
      </Routes>
      <Routes>
        <Route path="/detail/:id" element={<MovieDetail />} />
      </Routes>
    </StyledApp>
  );
}

export default App;
