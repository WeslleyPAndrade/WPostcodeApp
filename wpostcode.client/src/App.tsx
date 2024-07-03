import React, { useState } from 'react';
import SearchInput from './components/SearchInput.tsx';
import './App.css';
import Accordion from '@mui/material/Accordion';
import AccordionSummary from '@mui/material/AccordionSummary';
import AccordionDetails from '@mui/material/AccordionDetails';
import Typography from '@mui/material/Typography';
import ExpandMoreIcon from '@mui/icons-material/ExpandMore';
import Paper from '@mui/material/Paper';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Snackbar from '@mui/material/Snackbar';
import Alert from '@mui/material/Alert';


interface Address {
    index: number;
    address: string;
    kilometersDistance: string;
    milesDistance: string;
}

const App: React.FC = () => {
    const [response, setResponse] = useState<Address[]>([]);
    const [open, setOpen] = useState(false);


    const handlePostcodeSubmit = async (postcode: string) => {
        try {
            const res = await fetch(`api/v1/address/${postcode}`);
            const data = await res.json();
            setResponse(data);
        } catch (error) {
            setOpen(true);
            console.error('Error fetching data:', error);
        }
    };

    

    return (
        <div className="App">
            <h1>WPostcode search App</h1>
            <div >
                <SearchInput onSubmit={handlePostcodeSubmit} />
            </div>
            <Snackbar open={open} autoHideDuration={6000} onClose={() => setOpen(false)}
                anchorOrigin={{ vertical: 'bottom', horizontal: 'center' }}
            >
                <Alert
                    onClose={() => setOpen(false)}
                    severity="error"
                    variant="filled"
                    sx={{ width: '30rem' }}
                >
                    Invalid postcode!
                </Alert>
            </Snackbar>
            {response.length > 0 && (
                <div >
                    {response.map((item) => (
                        <Accordion key={item.index}>
                        <AccordionSummary
                            expandIcon={<ExpandMoreIcon />}
                            aria-controls="panel-content"
                            id="panel-header"
                            >
                                <Typography>{item.address}</Typography>
                        </AccordionSummary>
                        <AccordionDetails>
                                <TableContainer component={Paper}>
                                    <Table sx={{ minWidth: 650 }} size="small" aria-label="a dense table">
                                        <TableHead>
                                            <TableRow>
                                                <TableCell>Distance from airport</TableCell>
                                                <TableCell align="right">Kilometers distance</TableCell>
                                                <TableCell align="right">Miles distance</TableCell>
                                            </TableRow>
                                        </TableHead>
                                        <TableBody>
                                            <TableRow
                                                sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
                                            >
                                                <TableCell component="th" scope="row">
                                                    London Heathrow airport
                                                </TableCell>
                                                <TableCell align="right">{item.kilometersDistance}</TableCell>
                                                <TableCell align="right">{item.milesDistance}</TableCell>
                                            </TableRow>
                                        </TableBody>
                                    </Table>
                                </TableContainer>
                        </AccordionDetails>
                    </Accordion>

                ))}
                </div>
            )}
        </div>
    );
};


export default App;