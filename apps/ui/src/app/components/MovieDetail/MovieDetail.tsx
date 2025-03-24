import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import {
    Card,
    CardContent,
    Typography,
    Grid,
    Box,
    Avatar,
    Divider,
    CircularProgress
} from '@mui/material';
import { getMovie } from "../../services/getMovie";
import { Movie } from "../../services/getMovies";

export const MovieDetail = () => {

    const { id } = useParams<{ id: string }>();
    const [movie, setMovie] = useState<Movie | null>(null);

    useEffect(() => {
        const requestData = async () => {
            if (id) {
                const responseData = await getMovie(id);
                setMovie(responseData);
            }
        };

        requestData();
    }, [id]);

    return (
        <div>
            {movie ? (
                <Card sx={{ maxWidth: 1000, margin: 'auto', mt: 4, p: 2, boxShadow: 6 }}>
                    <Grid container spacing={3}>
                        {/* Poster */}
                        <Grid item xs={12} md={4}>
                            <Avatar
                                variant="square"
                                src={movie.poster}
                                alt={movie.title}
                                sx={{ width: '100%', height: '100%', borderRadius: 2 }}
                            />
                        </Grid>

                        {/* Info */}
                        <Grid item xs={12} md={8}>
                            <CardContent>
                                <Typography variant="h5" fontWeight="bold" gutterBottom>
                                    {movie.title} ({movie.year})
                                </Typography>
                                <Typography variant="body2" gutterBottom>
                                    <strong>Rated:</strong> {movie.rated} | <strong>Released:</strong> {movie.released} | <strong>Runtime:</strong> {movie.runtime}
                                </Typography>
                                <Typography variant="body2" gutterBottom>
                                    <strong>Genre:</strong> {movie.genre}
                                </Typography>
                                <Typography variant="body2" gutterBottom>
                                    <strong>Director:</strong> {movie.director}
                                </Typography>
                                <Typography variant="body2" gutterBottom>
                                    <strong>Actors:</strong> {movie.actors}
                                </Typography>
                                <Typography variant="body2" gutterBottom mt={2}>
                                    <strong>Plot:</strong> {movie.plot}
                                </Typography>

                                <Divider sx={{ my: 2 }} />

                                {/* Prices */}
                                <Box>
                                    <Typography variant="h6" gutterBottom>
                                        Available From:
                                    </Typography>
                                    <Grid container spacing={2}>
                                        {movie.providers.map((provider) => (
                                            <Grid item xs={6} key={provider.providerName}>
                                                <Box
                                                    sx={{
                                                        border: '1px solid #ccc',
                                                        borderRadius: 2,
                                                        p: 2,
                                                        textAlign: 'center',
                                                    }}
                                                >
                                                    <Typography variant="subtitle1" fontWeight="bold">
                                                        {provider.providerName}
                                                    </Typography>
                                                    <Typography variant="h6">${provider.price}</Typography>
                                                </Box>
                                            </Grid>
                                        ))}
                                    </Grid>
                                </Box>
                            </CardContent>
                        </Grid>
                    </Grid>
                </Card>
            ) : (
                <Box
                    sx={{
                        display: 'flex',
                        flexDirection: 'column',
                        alignItems: 'center',
                        justifyContent: 'center',
                        height: '60vh',
                        textAlign: 'center',
                    }}
                >
                    <CircularProgress size={60} thickness={4} />
                    <Typography variant="h6" sx={{ mt: 2 }}>
                        Loading
                    </Typography>
                </Box>
            )}
        </div>
    )
}