import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';
import { useEffect, useState } from 'react';
import { Movie, getMovies } from '../../services/getMovies';
import { Link } from 'react-router-dom';

export const Movies = () => {
    const [movies, setMovies] = useState<Movie[]>([]);

    useEffect(() => {
        const requestData = async () => {
            const responseData = await getMovies();
            setMovies(responseData);
        }

        requestData();
    }, []);


    return (
        <TableContainer component={Paper}>
            <Table sx={{ minWidth: 650 }} aria-label="simple table">
                <TableHead>
                    <TableRow>
                        <TableCell></TableCell>
                        <TableCell>Title</TableCell>
                        <TableCell>Genre</TableCell>
                        <TableCell align="right">Year</TableCell>
                        <TableCell>Rated</TableCell>
                        <TableCell>Director</TableCell>
                    </TableRow>
                </TableHead>
                <TableBody>
                    {movies.map((movie) => (
                        <TableRow
                            key={movie.id}
                            sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
                        >
                            <TableCell component="th" scope="row">
                                <img height={50} src={movie.poster} alt="poster" />
                            </TableCell>
                            <TableCell component="th" scope="row">
                                <Link to={`/detail/${movie.id}`}>{movie.title}</Link>
                            </TableCell>
                            <TableCell>{movie.genre}</TableCell>
                            <TableCell align="right">{movie.year}</TableCell>
                            <TableCell>{movie.rated}</TableCell>
                            <TableCell>{movie.director}</TableCell>
                        </TableRow>
                    ))}
                </TableBody>
            </Table>
        </TableContainer>
    );
}