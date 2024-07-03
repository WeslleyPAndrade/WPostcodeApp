import React, { useState } from 'react';
import InputBase from '@mui/material/InputBase';
import Paper from '@mui/material/Paper';
import Divider from '@mui/material/Divider';
import IconButton from '@mui/material/IconButton';
import SearchIcon from '@mui/icons-material/Search';

interface PostcodeInputProp {
    onSubmit: (text: string) => void;
}

const SearchInput: React.FC<PostcodeInputProp> = ({ onSubmit }) => {
    const [postcode, setPostcode] = useState<string>('');

    const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        setPostcode(e.target.value);
    };

    const handleSubmit = (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        onSubmit(postcode);
    };

    return (

            
            <Paper
            component="form"
            sx={{ p: '2px 4px', display: 'flex', alignItems: 'center', width: '50rem', mb: '4rem' }}
            onSubmit={handleSubmit}
            >
                <InputBase
                    sx={{  flex: 1 }}
                    placeholder="Search Postcode"
                    value={postcode}
                    onChange={handleChange}
                    inputProps={{ 'aria-label': 'search postcode' }}
                />

                <Divider sx={{ height: 28, m: 0.5 }} orientation="vertical" />
                <IconButton color="primary" sx={{ p: '10px' }} aria-label="search" type="submit">
                    <SearchIcon />
                </IconButton>
            </Paper>

    );
};

export default SearchInput;